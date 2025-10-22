using System.Numerics;
using _01.Code.Entities;

namespace _01.Code.FSM
{
    public abstract class EntityState
    {
        protected Entities.Entity _entity;
        protected int _animationHash;
        protected EntityAnimator _entityAnimator;

        public EntityState(Entities.Entity entity, int animationHash)
        {
            _entity = entity;
            _animationHash = animationHash;
            _entityAnimator = entity.GetCompo<EntityAnimator>();
        }

        public virtual void Enter()
        {
            _entityAnimator.SetParam(_animationHash, true);
        }

        public virtual void Update() 
        {
            
        }

        public virtual void Exit()
        {
            _entityAnimator.SetParam(_animationHash, false);
        }
    }
}