using _01.Code.Entities;
using UnityEngine;

namespace _01.Code.Players
{
    public class PlayerMovement : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveSpeed = 8f;

        [HideInInspector] public Vector2 velocity;

        private Vector2 _movementDirection;

        private Entities.Entity _entity;
        public void Initialize(Entities.Entity entity)
        {
            _entity = entity;
        }

        private void Update()
        {
            rb.linearVelocity = velocity * moveSpeed;
        }

    }
}