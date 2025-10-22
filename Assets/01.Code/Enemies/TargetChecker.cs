using System;
using _01.Code.Entities;
using UnityEngine;

namespace _01.Code.Enemies
{
    public class TargetChecker : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private float radius = 0.5f;
        [SerializeField] private LayerMask targetLayer ;
        private GameObject _target;
        private Entities.Entity _entity;
        public void Initialize(Entities.Entity entity)
        {
            _entity = entity;
        }
        public GameObject CheckTarget()
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, targetLayer);
            
            if (collider != null)
            {
                _target = collider.gameObject;
                return collider.gameObject;
            }
            else
            {
                return null;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}