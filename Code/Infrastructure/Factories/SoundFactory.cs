using _GAME.Code.Data.Sound;
using _GAME.Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Infrastructure.Factories
{
    public class SoundFactory : IService
    {
        [Inject] private StaticDataService _staticDataService;
        

        public AudioSource CreateSoundByName(SoundName soundName, Vector3 pos, float destroyTime = 1f)
        {
            AudioSource newAudioSource = GameObject.Instantiate(_staticDataService.ReturnAudioSourcePrefabByName(soundName));
            newAudioSource.transform.position = pos;
            newAudioSource.Play();
            
            GameObject.Destroy(newAudioSource.gameObject, destroyTime);
            
            return newAudioSource;
        }

        public void CreateRandomBodyHitSound(Vector3 pos, float destroyTime = 0.5f)
        {
            int randomValue = Random.Range(0, 1);

            switch (randomValue)
            {
                case 0:
                    CreateSoundByName(SoundName.Body_Hit_Sound_1, pos, destroyTime);
                    break;
                case 1:
                    CreateSoundByName(SoundName.Body_Hit_Sound_2, pos, destroyTime);
                    break;
            }
            
        }
    }
}