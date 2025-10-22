using _01.Code.Entities;
using UnityEngine;

namespace _01.Code.Buildings
{
    public class BuildingAttacker : MonoBehaviour, IEntityComponent
    {
        private float radius;
        public void Initialize(Entities.Entity entity)
        {
            
        }

        private void AttackCheck()
        { 
                        
        }

        private void Attack()
        {
            
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 5f);
        }

    }
}