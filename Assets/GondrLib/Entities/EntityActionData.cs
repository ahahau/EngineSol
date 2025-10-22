using UnityEngine;

namespace GondrLib.Entities
{
    public class EntityActionData : MonoBehaviour, IEntityComponent
    {
        private Entity _entity;
        
        public Vector3 HitPoint { get; set; }
        public Vector3 HitNormal { get; set; }
        public float LastDamage { get; set; }
        
        public void Initialize(Entity entity)
        {
            _entity = entity;
        }
    }
}