using _GAME.Code.Data.VFX;
using _GAME.Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Infrastructure.Factories
{
    public class VfxFactory : IService
    {
        [Inject] private StaticDataService _staticDataService;


        public void SpawnEffectGlobalPosRot(ParticleSystem effect, Vector3 spawnPos, Quaternion spawnRotation, float destroyDelay, Transform parent = null)
        {
            ParticleSystem newEffect = GameObject.Instantiate(effect, parent);
            newEffect.transform.position = spawnPos;
            newEffect.transform.rotation = spawnRotation;
            
            GameObject.Destroy(newEffect.gameObject, destroyDelay);
        }

        public void SpawnEffectLocalPosGlobalRot(ParticleSystem effect, Vector3 spawnPos, Quaternion spawnRotation, float destroyDelay, Transform parent = null)
        {
            ParticleSystem newEffect = GameObject.Instantiate(effect, parent);
            newEffect.transform.localPosition = spawnPos;
            newEffect.transform.rotation = spawnRotation;
            
            GameObject.Destroy(newEffect.gameObject, destroyDelay);
        }

        public void SpawnEffectLocalPosRot(ParticleSystem effect, Vector3 spawnPos, Quaternion spawnRotation, float destroyDelay, Transform parent = null)
        {
            ParticleSystem newEffect = GameObject.Instantiate(effect, parent);
            newEffect.transform.localPosition = spawnPos;
            newEffect.transform.localRotation = spawnRotation;
            
            GameObject.Destroy(newEffect.gameObject, destroyDelay);
        }
        
        public void SpawnEffectByType(VfxType vfxType, Vector3 spawnPos, Quaternion spawnRotation, float destroyDelay)
        {
            if (vfxType == VfxType.None) return;
            
            ParticleSystem newEffect = _staticDataService.ReturnEffectByType(vfxType);
            SpawnEffectGlobalPosRot(newEffect, spawnPos, spawnRotation, destroyDelay);
        }
    }
}