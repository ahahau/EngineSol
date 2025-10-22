using _01.Code.Entities;
using UnityEngine;

namespace _01.Code.Players.Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        //[SerializeField] private 
        private float _damage;
        public void Initialize(int damage, float speed, float bulletLifeTime)
        {
            _damage = damage;
            rb.linearVelocity = transform.right * speed;
            Destroy(gameObject, bulletLifeTime);
        }
        private void OnTriggerEnter2D(Collider2D entity)
        {
            if(entity.gameObject.layer != LayerMask.NameToLayer("Building"))
                if (entity.TryGetComponent<IDamageable>(out var damageable))
                {
                    damageable.ApplyDamage(_damage);
                }
            Destroy(gameObject);
            //todo add hit effects
            //todo add Pooling
        }
    }
}