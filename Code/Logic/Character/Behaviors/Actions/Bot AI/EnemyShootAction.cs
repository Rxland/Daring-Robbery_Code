using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions.Bot_AI
{
    public class EnemyShootAction : CharacterAction
    {
        public override void OnStart()
        {
            BotCharacterRef.AiAttack.CanShoot = false;
            
            Transform MuzzleT = BotCharacterRef.AiAttack.CurrentWeapon.GetAttachmentManager().GetEquippedMuzzle().GetSocket();
            
             BotCharacterRef.VfxFactory.SpawnEffectLocalPosRot(BotCharacterRef.AiAttack.CurrentWeapon.ShootMuzzleEffect,
                Vector3.zero,  Quaternion.identity, 1f, MuzzleT);
            
            BotCharacterRef.AiAttack.CurrentWeapon.Fire();
            BotCharacterRef.Recoil.Fire(1f);
        }
    }
}