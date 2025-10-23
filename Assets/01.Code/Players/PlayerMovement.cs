using _01.Code.Entities;
using UnityEngine;

namespace _01.Code.Players
{
    public class PlayerMovement : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveSpeed = 8f;
        [SerializeField] private GameObject weaponHolder;
        [HideInInspector] public Vector2 velocity;

        private Vector2 _movementDirection;

        private Player _entity;
        public void Initialize(Entities.Entity entity)
        {
            _entity = entity as Player;
        }

        private void Update()
        {
            rb.linearVelocity = velocity * moveSpeed;
            Vector2 direction = new Vector3(_entity.MouseWorldPosition.x,_entity.MouseWorldPosition.y) - weaponHolder.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (angle > 90 || angle < -90)
            {
                weaponHolder.transform.rotation = Quaternion.Euler(180, 0, -angle);
            }
            else
            {
                weaponHolder.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}