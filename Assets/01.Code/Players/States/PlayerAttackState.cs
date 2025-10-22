using _01.Code.Players.Combat;
using UnityEngine;

namespace _01.Code.Players.States
{
    public class PlayerAttackState : PlayerState
    {
        private WeaponController _weaponController;
        public PlayerAttackState(Entities.Entity entity, int animationHash) : base(entity, animationHash)
        {
            _weaponController = entity.GetCompo<WeaponController>();
        }
        public override void Enter()
        {
            base.Enter();
            _weaponController.Shooting();
        }
    }
}