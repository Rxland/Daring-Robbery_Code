using System;
using _GAME.Code.Data.Sound;
using _GAME.Code.Data.VFX;
using _GAME.Code.Logic.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _GAME.Code.Logic.Drill
{
    public class DrillInteractable : Interactable
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _remainingTimeSecondsValue;
        [SerializeField] private float _brokeTimeSecondsOffset;
        private float _brokeTimeSecondsValue;
        private float _remainingTimeSecondsValueFireTime;
        private float _remainingTimeSecondsValueForFilledImg;
        
        [SerializeField] private Transform _drillRotationPart;

        [Header("Materials")] 
        [SerializeField] private SkinnedMeshRenderer _baseSkinnedMeshRenderer;
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private Material _transperentMaterial;

        [Header("Effects")]
        [SerializeField] private ParticleSystem _drillEffect;

        [Header("UI")] 
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TextMeshProUGUI _drillInProgressText;
        [SerializeField] private TextMeshProUGUI _remainingTimeText;
        [SerializeField] private TextMeshProUGUI _startDrillWorkText;
        [SerializeField] private TextMeshProUGUI _endedDrillWorkText;
        [SerializeField] private TextMeshProUGUI _brokenDrillWorkText;

        [Header("Progress Bar")] 
        [SerializeField] private Image _panelImg;
        [SerializeField] private Image _progressBarMainBg;
        [SerializeField] private Image _progressBarFilled;

        [Header("Colors")] 
        public Color _defaultPanelColor;
        public Color _brokenPanelColor;

        [Header("Sounds")] 
        [SerializeField] private AudioSource _drillWorkSound;
        [SerializeField] private AudioSource _drillBrokeSound;
        [SerializeField] private SoundName _drillDestroySoundName;

        [Header("Other")] 
        [SerializeField] private DrillIndicator _drillIndicator;
        
        private DrillWorkStates _currentDrillWorkState;
        
        public UnityEvent DrillEndUnityEvent;

        private bool _wasBroken;
        
        private void Start()
        {
            _baseSkinnedMeshRenderer.material = _transperentMaterial;

            _brokeTimeSecondsValue = Random.Range(_brokeTimeSecondsOffset, _remainingTimeSecondsValue - _brokeTimeSecondsOffset);
            _remainingTimeSecondsValueForFilledImg = _remainingTimeSecondsValue;
            
            _drillIndicator.Init();
        }
        private void Update()
        {
            if (_currentDrillWorkState != DrillWorkStates.InWork) return;

            RotateDrill();
            Timer();
            FillProgress();
        }
        
        public override void Interact(Transform whoInteractT)
        {
            switch (_currentDrillWorkState)
            {
                case DrillWorkStates.NotActivated:
                    ActivateDrill();
                    break;
                case DrillWorkStates.Broken:
                    ActivateDrill();
                    break;
            }
        }

        public override void Interact()
        {
            
        }

        private void SwitchState(DrillWorkStates drillWorkState)
        {
            if (drillWorkState == _currentDrillWorkState) return;
            
            _currentDrillWorkState = drillWorkState;
        }
        
        private void ActivateDrill()
        {
            SwitchState(DrillWorkStates.InWork);
            
            _drillEffect.gameObject.SetActive(true);
            
            _startDrillWorkText.gameObject.SetActive(false);
            _brokenDrillWorkText.gameObject.SetActive(false);
            _drillInProgressText.gameObject.SetActive(true);
            _progressBarMainBg.gameObject.SetActive(true);
            _remainingTimeText.gameObject.SetActive(true);

            _drillBrokeSound.Stop();
            _drillWorkSound.Play();

            _panelImg.color = _defaultPanelColor;
            _baseSkinnedMeshRenderer.material = _defaultMaterial;

            _drillIndicator.SetActiveIndicator(true);
            
            CanInteract = false;
        }
        private void DrillDone()
        {
            DrillEndUnityEvent?.Invoke();
            
            SwitchState(DrillWorkStates.WorkDone);

            _endedDrillWorkText.gameObject.SetActive(true);
            _drillInProgressText.gameObject.SetActive(false);
            _remainingTimeText.gameObject.SetActive(false);
            _progressBarMainBg.gameObject.SetActive(false);
            _drillEffect.gameObject.SetActive(false);
            
            _drillIndicator.SetProgressImgToDefaultColor();
        }
        private void DrillBroke()
        {
            SwitchState(DrillWorkStates.Broken);
            
            _drillEffect.gameObject.SetActive(false);
            _drillInProgressText.gameObject.SetActive(false);
            _brokenDrillWorkText.gameObject.SetActive(true);
            
            _drillWorkSound.Stop();
            _drillBrokeSound.Play();
            
            _panelImg.color = _brokenPanelColor;

            _wasBroken = true;
            CanInteract = true;
            
            _drillIndicator.SetProgressImgToBrokenColor();
        }
        
        private void RotateDrill()
        {
            Vector3 newRotation = _drillRotationPart.localEulerAngles;
            newRotation.y += -_rotationSpeed * Time.deltaTime;
            _drillRotationPart.localEulerAngles = newRotation;
        }

        private void FillProgress()
        {
            _remainingTimeSecondsValueFireTime += Time.deltaTime;
            _progressBarFilled.fillAmount = _remainingTimeSecondsValueFireTime / _remainingTimeSecondsValueForFilledImg;
            _drillIndicator.UpdateProgressFilledImg(_remainingTimeSecondsValueFireTime, _remainingTimeSecondsValueForFilledImg);
        }
        private void Timer()
        {
            if (_currentDrillWorkState == DrillWorkStates.WorkDone) return;
            
            _remainingTimeSecondsValue -= Time.deltaTime;
            _brokeTimeSecondsValue -= Time.deltaTime;
            
            int minutes = Mathf.FloorToInt(_remainingTimeSecondsValue / 60);
            int seconds = Mathf.FloorToInt(_remainingTimeSecondsValue % 60);

            _remainingTimeText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");

            if (!_wasBroken && _brokeTimeSecondsValue <= 0)
            {
                DrillBroke();
            }
            if (_remainingTimeSecondsValue <= 0f)
            {
                DrillDone();
            }
        }
        public void DestroyDrill()
        {
            VfxFactory.SpawnEffectByType(VfxType.DrillDestroy, transform.position, Quaternion.identity, 1f);
            SoundFactory.CreateSoundByName(_drillDestroySoundName, transform.position);
            
            Destroy(gameObject);
        }
    }
}