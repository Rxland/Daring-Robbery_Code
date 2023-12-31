﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace _GAME.Code.UI
{
    public class RenderTextureRaycast : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] protected Camera UICamera;
        [SerializeField] protected RectTransform RawImageRectTrans;
        [SerializeField] protected Camera RenderToTextureCamera;
    
        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(RawImageRectTrans, eventData.position, UICamera, out localPoint);
            Vector2 normalizedPoint = Rect.PointToNormalized(RawImageRectTrans.rect, localPoint);

            var renderRay = RenderToTextureCamera.ViewportPointToRay(normalizedPoint);
            if (Physics.Raycast(renderRay, out var raycastHit))
            {
                Debug.Log("Hit: " + raycastHit.collider.gameObject.name);
            }
            else
            {
                Debug.Log("No hit object");
            }
        }
    }
}