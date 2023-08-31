using System.Collections.Generic;
using _GAME.Code.Features;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic;
using _GAME.Code.Logic.Character.Ref;
using _GAME.Code.Logic.Interaction.Interactables;
using _GAME.Code.StaticData;
using _GAME.Code.StaticData.Weapon_Stuff;
using _GAME.Code.Types.Weapon_Stuff;
using DG.Tweening;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Infrastructure.Factories
{
    public class GameFactory : IService
    {
        public PlayerCharacterRef Player;
        public Camera PlayerCamera => _playerCamera;
        
        private Camera _playerCamera;
        
        [Inject] private StaticDataService _staticDataService;
        [Inject] private DiContainer _diContainer;
        [Inject] private WeaponsFeature _weaponsFeature;
        

        public void SpawnPlayer(Transform spawnPoint)
        {
            PlayerStaticData playerStaticData = _staticDataService.ReturnPlayerStaticData;
            Player = _diContainer.InstantiatePrefabForComponent<PlayerCharacterRef>(playerStaticData.Prefab);
            Player.transform.position = spawnPoint.position;
            Player.transform.rotation = spawnPoint.rotation;
            
            Player.PlayerWeaponEquipper.SetEquippedWeapons();
            DOVirtual.DelayedCall(3f,() => Player.Character.OnHolster(true));
            
            _playerCamera = Player.Camera;
        }

        public Backpack SpawnBag(Vector3 spawnPos)
        {
            PlayerStaticData playerStaticData = _staticDataService.ReturnPlayerStaticData;
            Backpack newBag = _diContainer.InstantiatePrefabForComponent<Backpack>(playerStaticData.BagPrefab);
            newBag.transform.position = spawnPos;

            return newBag;
        }
        public Treasure SpawnTreasureByPrefab(Treasure prefab)
        {
            return _diContainer.InstantiatePrefabForComponent<Treasure>(prefab);
        }

        public Weapon SpawnWeapon(WeaponTypeName weaponTypeName, WeaponSkinName weaponSkinName)
        {
            WeaponStaticData weaponStaticData = _weaponsFeature.GetWeaponStaticData(weaponTypeName, weaponSkinName);
            
            Weapon newWeapon = _diContainer.InstantiatePrefabForComponent<Weapon>(weaponStaticData.WeaponPrefab);
            
            return newWeapon;
        }

        public Weapon SpawnWeaponForShopUi(Weapon weaponPrefab, Transform spawnPont)
        {
            Weapon newWeapon = _diContainer.InstantiatePrefabForComponent<Weapon>(weaponPrefab);
            newWeapon.transform.position = spawnPont.position;
            newWeapon.transform.rotation = spawnPont.rotation;
            
            return newWeapon;
        }

        public void SpawnLootInPoints(List<Transform> _spawnPoints)
        {
            SafeDepositStaticData safeDepositStaticData = _staticDataService.SafeDepositStaticData;
            
            foreach (Transform spawnLootPoint in _spawnPoints)
            {
                Treasure newTreasure = SpawnTreasureByPrefab(
                    safeDepositStaticData.SafeDepositRandomInBoxTreasures[Random.Range(0, safeDepositStaticData.SafeDepositRandomInBoxTreasures.Count)]);
                newTreasure.transform.parent = spawnLootPoint.transform;
                newTreasure.transform.position = spawnLootPoint.position;
            }
        }
    }
}