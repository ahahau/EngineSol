using _01.Code.Entities;
using UnityEngine.Tilemaps;

namespace _01.Code.Buildings
{
    public abstract class Building : Entities.Entity, IPlaceable
    {
        private EntityHealth _health;
        public Tile Tile { get; set; }
        protected override void Awake()
        {
            base.Awake();
            _health = GetCompo<EntityHealth>();
        }
        public virtual void FixBuilding(float healAmount)
        {
            _health.Heal(healAmount);
        }

    }
}