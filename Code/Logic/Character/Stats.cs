using _GAME.Code.Data.Sound;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.UI;
using DG.Tweening;
using RootMotion.FinalIK;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace _GAME.Code.Logic.Character
{
    public class Stats : MonoBehaviour
    {
        public float MaxHp;
        [ReadOnly] public float CurrentHp;
        public HitReaction HitReaction;
        public RagdollUtility RagdollUtility;
        public float HitForce;
        [Space]
        
        [Header("Movement")]
        public float RotateToSpeed;
        [Space]

        [ReadOnly] public bool IsKilled;
        [SerializeField] private bool _isPlayer;

        public UnityEvent CustomDieUEvent;
        
        [Inject] private HudUiRef _hudUiRef;
        [Inject] private GameFactory _gameFactory;
        [Inject] private UiFactory _uiFactory;
        [Inject] private SoundFactory _soundFactory;
        
        
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            CurrentHp = MaxHp;
        }

        [Button]
        public void TakeDamage(float damage, Stats damageReceivedFromStats, Vector3 hitPos)
        {
            if (IsKilled) return;
            
            CurrentHp = Mathf.Clamp(CurrentHp - damage, 0f, MaxHp);
            
            if (CurrentHp <= 0)
            {
                Kill(hitPos);
            }
            
            Hit(damageReceivedFromStats, hitPos);
        }

        private void Hit(Stats damageReceivedFromStats, Vector3 hitPos)
        {
            if (damageReceivedFromStats._isPlayer)
            {
                _uiFactory.SpawnHitEnemyIndicator(hitPos, IsKilled);
            }
            
            if (_isPlayer)
            {
                _hudUiRef.PlayerHpBarLogic.TakeDamageAction();
            }
            _soundFactory.CreateRandomBodyHitSound(hitPos);
        }
        
        private void Kill(Vector3 hitPos)
        {
            IsKilled = true;

            if (_isPlayer)
            {
                PlayerKillActions();
            }
            else if (RagdollUtility)
            {
                RagdollUtility.EnableRagdoll();
                _soundFactory.CreateSoundByName(SoundName.Enemy_Killed_Sound_1, hitPos);
            }
            CustomDieUEvent?.Invoke();
        }

        private void PlayerKillActions()
        {
            _gameFactory.Player.Character.enabled = false;
            _gameFactory.Player.Movement.enabled = false;
            _gameFactory.Player.FootstepPlayer.enabled = false;
            _gameFactory.Player.PlayerInput.enabled = false;
            
            _gameFactory.Player.Camera.transform.SetParent(null);

            Vector3 cameraPos = _gameFactory.Player.Camera.transform.position;
            Vector3 cameraRot = _gameFactory.Player.Camera.transform.eulerAngles;

            DOTween.Sequence()
                .Append(_gameFactory.Player.Camera.transform.DOMove(new Vector3(cameraPos.x - 2f,
                    _gameFactory.Player.transform.position.y + 0.5f, cameraPos.z + 2f), 0.5f).SetEase(Ease.OutBack))
                .Append(_gameFactory.Player.Camera.transform.DORotate(new Vector3(cameraRot.x, cameraRot.y, 25f), 0.5f))
                .AppendCallback(() =>
                {
                    Vector3 newPlayerPos = _gameFactory.Player.Camera.transform.position;
                    newPlayerPos.y -= 2f;
                    newPlayerPos.z -= 1f;
                    
                    _gameFactory.Player.transform.position = newPlayerPos;
                    _gameFactory.Player = null;
                });
        }
        
    }
}