using DG.Tweening;
using UnityEngine;

namespace _GAME.Code.Logic.Customer
{
    public class CustomerDie : MonoBehaviour
    {
        [SerializeField] private Customer _customer;
        
        public void DieActions()
        {
            DOTween.Sequence()
                .AppendInterval(2f)
                .AppendCallback(() =>
                {
                    foreach (Collider ragdollColider in _customer.RagdollColiders)
                    {
                        ragdollColider.enabled = false;
                    }
                })
                .Append(transform.DOMoveY(transform.position.y - 1f, 2f))
                .AppendCallback(() =>
                {
                    GameObject.Destroy(gameObject);
                });
        }
    }
}