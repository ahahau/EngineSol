using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace _01.Code.Entities
{
    public class EntityHealth : MonoBehaviour, IEntityComponent, IDamageable
    {
        private Entity _entity;
        [SerializeField] private float maxHealth = 100f;
        [field:SerializeField] public float currentHealth { get; private set; }
        public void Initialize(Entity entity)
        {
            _entity = entity;
            currentHealth = maxHealth;
        }

        public void ApplyDamage(float damageData)
        {
            currentHealth -= damageData;
            _entity.OnHitEvent?.Invoke();
            if (currentHealth < 0)
            {
                _entity.OnDeathEvent?.Invoke();
            }
        }
        public void Heal(float healAmount)
        {
            currentHealth += healAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}