using UnityEngine;
namespace _01.Code.Players.States
{
    public class PlayerIdleState : PlayerState
    {
        private PlayerMovement _movement;
        public PlayerIdleState(Entities.Entity entity, int animationHash) : base(entity, animationHash)
        {
            _movement = entity.GetCompo<PlayerMovement>();
        }

        public override void Update()
        {
            base.Update();
            Vector2 movementKey = _player.PlayerInput.movement;
            if (movementKey.magnitude > _inputThreshold)
            {
                _player.ChangeState("MOVE");
            }
        }
    }
}