using System;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME.Code.Logic.Drill
{
    public class DrillIndicator : MonoBehaviour
    {
        public Image ProgressFilledImg;
        public Waypoint_Indicator WaypointIndicator;
        [SerializeField] private Color _drillDefaultProgressColor;
        [SerializeField] private Color _drillBrokenProgressColor;
        

        public void Init()
        {
            SetActiveIndicator(false);
            ProgressFilledImg.fillAmount = 0f;
        }

        public void UpdateProgressFilledImg(float firstValue, float secondValue)
        {
            WaypointIndicator.gameObjectIndicator.GetComponent<DrillIndicator>().ProgressFilledImg
                .fillAmount = firstValue / secondValue;
            ProgressFilledImg.fillAmount = firstValue / secondValue;
        }

        public void SetProgressImgToDefaultColor()
        {
            WaypointIndicator.gameObjectIndicator.GetComponent<DrillIndicator>().ProgressFilledImg.color =
                _drillDefaultProgressColor;
            ProgressFilledImg.color = _drillDefaultProgressColor;
        }
        public void SetProgressImgToBrokenColor()
        {
            WaypointIndicator.gameObjectIndicator.GetComponent<DrillIndicator>().ProgressFilledImg.color =
                _drillBrokenProgressColor;
            ProgressFilledImg.color = _drillBrokenProgressColor;
        }
        public void SetActiveIndicator(bool activeMode)
        {
            gameObject.transform.parent.gameObject.SetActive(activeMode);
        }
        private void OnDisable()
        {
            // WaypointIndicator.gameObjectIndicatorChangedEvent -= UpdateProgressFilledImg;
        }

        // private void UpdateProgressFilledImg()
        // {
        //     DrillIndicator drillIndicator = WaypointIndicator.gameObjectIndicator.GetComponent<DrillIndicator>();
        //     
        //     ProgressFilledImg = drillIndicator.ProgressFilledImg;
        // }
        

    }
}