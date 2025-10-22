using _01.Code.FSM;
using UnityEngine;

namespace _01.Code.Players
{
    public abstract class PlayerState : EntityState
    {
        protected Player _player;
        protected readonly float _inputThreshold = 0.05f;
        
        protected PlayerState(Entities.Entity entity, int animationHash) : base(entity, animationHash)
        {
            _player = entity as Player;
            Debug.Assert(_player != null, $"Player state using only in player");
        }

        public override void Update()
        {
            base.Update();
            Vector3 mousePosition = _player.PlayerInput.GetWorldPosition();
            _player.RotateToTarget(mousePosition);
        }
    }
}