using System.Collections.Generic;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Logic.Character.Animation;
using _GAME.Code.Logic.Enemy;
using BehaviorDesigner.Runtime;
using Pathfinding;
using RootMotion.FinalIK;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Character.Ref
{
    public class BotCharacterRef : MonoBehaviour
    {
        [ReadOnly] public PlayerCharacterRef PlayerCharacterRef;
        public BehaviorTree BehaviorTree;
        [Space] 
        public Transform PlayerTarget;
        public Transform HeadT;
        public Transform Spine1T;
        public Transform CenterPoint;

        [Space]
        public List<Transform> PatrolPoints;
        [HideInInspector] public int PatrolCurrentPointId;
        [Space] 
        public LayerMask AttackLayerMask;
        public CharacterAnimator CharacterAnimator;
        public AIPath AIPath;
        public Seeker Seeker;
        public Stats Stats;
        public AiAttack AiAttack;

        [Header("Strafe")]
        public float StartStrafeDist;
        public float MinRandomStrafePointRange;
        public float MaxRandomStrafePointRange;
        public bool IsStrafing;
        
        [Header("IK")] 
        public LookAtIK LookAtIK;
        public AimIK AimIK;
        public Recoil Recoil;
        public EnemyIkController EnemyIkController;
        public List<Collider> RagdollColiders;

        [Header("Movement")] 
        public bool CanMove;
        public Transform MoveToTarget;
        public float ReachedMoveToTargetRange;

        [Header("Aim")] 
        public bool CanAim;
        public Transform AimTarget;
        
        [Header("Services")]
        private VfxFactory _vfxFactory;
        public VfxFactory VfxFactory => _vfxFactory;
        
        private EnemyFactory _enemyFactory;
        public EnemyFactory EnemyFactory => _enemyFactory;
        
        
        [Inject]
        private void Constructor(VfxFactory vfxFactory,
                                 EnemyFactory enemyFactory)
        {
            _vfxFactory = vfxFactory;
            _enemyFactory = enemyFactory;
        }
        
        private void Awake()
        {
            Stats = GetComponent<Stats>();
        }

        private void Start()
        {
            MoveToTarget.SetParent(null);   
        }
        
        
    }
}