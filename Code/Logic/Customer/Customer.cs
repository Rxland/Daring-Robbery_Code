using System.Collections.Generic;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic.Character;
using _GAME.Code.Logic.Game_Behavior;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Customer
{
    #region Require Compoents
    [RequireComponent(typeof(CustomerAnimator))]
    [RequireComponent(typeof(Stats))]
    [RequireComponent(typeof(AIPath))]
    [RequireComponent(typeof(CustomerDie))]
    #endregion

    
    public class Customer : MonoBehaviour
    {
        public CustomerAnimator CustomerAnimator;
        public Stats Stats;
        public AIPath AIPath;
        public Seeker Seeker;
        public CustomerDie CustomerDie;
        [Space]
        
        public List<Collider> RagdollColiders;

        [HideInInspector] [Inject] public GameBehavior GameBehavior;
        [HideInInspector] [Inject] public EnvFactory EnvFactory;
        [HideInInspector] [Inject] public StaticDataService StaticDataService;
        
        
        private void Reset()
        {
            CustomerAnimator = GetComponent<CustomerAnimator>();
            Stats = GetComponent<Stats>();
            AIPath = GetComponent<AIPath>();
            CustomerDie = GetComponent<CustomerDie>();
        }
    }
}