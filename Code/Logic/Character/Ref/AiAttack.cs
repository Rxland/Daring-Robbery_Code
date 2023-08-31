using System;
using System.Collections.Generic;
using _GAME.Code.Types.Weapon_Stuff;
using BehaviorDesigner.Runtime;
using InfimaGames.LowPolyShooterPack;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Ref
{
    public class AiAttack : MonoBehaviour
    {
        public BotCharacterRef BotCharacterRef;
        [Space]
        
        public Weapon CurrentWeapon;
        public List<Weapon> AllWeaponsInContainer;
        [Space] 
        public LayerMask AttackTargetLayerMask;
        public float AttackRange;
        public float AttackMinCloseToTargetRange;
        public int CurrentWeaponId;
        public bool CanShoot = true;




        [Button]
        public void SetWeaponByName(WeaponTypeName weaponTypeName)
        {
            foreach (Weapon weapon in AllWeaponsInContainer)
            {
                if (weapon.weaponTypeName == weaponTypeName)
                {
                    CurrentWeapon = weapon;
                    BotCharacterRef.AimIK.solver.transform = weapon.AimTransform;
                    
                    BotCharacterRef.CharacterAnimator.SetWeaponId(weapon.WeaponIdForAnimator);
                    BotCharacterRef.BehaviorTree.SetVariable("ShootDelay", (SharedFloat)weapon.BotFireRate);

                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
            }
        }

    }
}