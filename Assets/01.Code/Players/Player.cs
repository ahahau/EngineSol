using System;
using _01.Code.Entities;
using _01.Code.Entity;
using _01.Code.FSM;
using UnityEngine;

namespace _01.Code.Players
{
    public class Player : Entities.Entity
    {
        [field:SerializeField] public PlayerInputSO PlayerInput { get; private set; }
        [SerializeField] private StateDataSO[] stateDataList;
        
        private EntityStateMachine _stateMachine;
        private PlayerMovement _movement;
        private EntityHealth _health;
        
        [HideInInspector] public Vector2 MouseWorldPosition {get; private set;}
        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new EntityStateMachine(this, stateDataList);
            _movement = GetCompo<PlayerMovement>();
            _health = GetCompo<EntityHealth>();
            PlayerInput.OnBuildingModeKeyPressed += OnBuildingModeHandle;
            PlayerInput.OnAttackKeyPressed += OnAttackHandle;
        }


        private void OnDestroy()
        {
            PlayerInput.OnBuildingModeKeyPressed -= OnBuildingModeHandle;
            PlayerInput.OnAttackKeyPressed -= OnAttackHandle;
        }

        private void OnBuildingModeHandle(bool isBuilding)
        {
            ChangeState(isBuilding ? "BUILDING" : "IDLE");
        }
        private void OnAttackHandle()
        {
            if (_stateMachine.CurrentState.GetType() != typeof(States.PlayerBuildingState))
            {
                //ChangeState("ATTACK");
            }
        }

        private void Start()
        {
            const string idle = "IDLE";
            _stateMachine.ChangeState(idle);
        }
        
        private void Update()
        {
            _stateMachine.UpdateStateMachine();
            MouseWorldPosition = PlayerInput.GetWorldPosition();
        }
        
        public void ChangeState(string newStateName, bool force = false) 
            => _stateMachine.ChangeState(newStateName, force);
    }
}