using System.Collections;
using UnityEngine;

namespace _GAME.Code.Logic.Interaction.Interactables
{
    public class ATM : Interactable
    {
        [SerializeField] private Transform _trasuareSpawnPoint;
        [Space]
        [SerializeField] private int _trasuaresToSpawnAmountMin;
        [SerializeField] private int _trasuaresToSpawnAmountMax;
        [Space]
        [SerializeField] private float _trasuaresToSpawnRate;
        [Space]
        [SerializeField] private float _trasuaresToSpawnForceMin;
        [SerializeField] private float _trasuaresToSpawnForceMax;
        
        private float _trasuaresToSpawnAmount;

        public override void Interact(Transform whoInteractT) { }

        public override void Interact()
        {
            CanInteract = false;

            StartCoroutine(SpawnTreasuresIE());
        }

        private IEnumerator SpawnTreasuresIE()
        {
            _trasuaresToSpawnAmount = Random.Range(_trasuaresToSpawnAmountMin, _trasuaresToSpawnAmountMax);
            
            while (_trasuaresToSpawnAmount > 0)
            {
                _trasuaresToSpawnAmount--;

                Treasure randomTreasurePrefab =
                    StaticDataService.ATMStaticData.TreasuresList[
                        Random.Range(0, StaticDataService.ATMStaticData.TreasuresList.Count)];
                Treasure newTreasure = GameFactory.SpawnTreasureByPrefab(randomTreasurePrefab);
                newTreasure.transform.position = _trasuareSpawnPoint.transform.position;
                Rigidbody newTreasureRb = newTreasure.gameObject.AddComponent<Rigidbody>();
                float force = Random.Range(_trasuaresToSpawnForceMin, _trasuaresToSpawnForceMax);
                
                newTreasureRb.transform.rotation = _trasuareSpawnPoint.rotation;
                newTreasureRb.AddForce(_trasuareSpawnPoint.forward * force);
                
                yield return new WaitForSeconds(_trasuaresToSpawnRate);
            }
        }
    }
}