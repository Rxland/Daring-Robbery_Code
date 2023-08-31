using _GAME.Code.Logic.Player;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _GAME.Code.Logic.Character.Ref
{
    public class PlayerCharacterRef : MonoBehaviour
    {
        public Camera Camera;
        public Stats Stats;
        
        public InfimaGames.LowPolyShooterPack.Character Character;
        public InfimaGames.LowPolyShooterPack.Inventory Inventory;
        
        public Movement Movement;
        public FootstepPlayer FootstepPlayer;
        public PlayerInput PlayerInput;
        public PlayerWeaponEquipper PlayerWeaponEquipper;
        [Space]
        
        public Transform FirePoint;
        public Transform LookAtPoint;
    }
}