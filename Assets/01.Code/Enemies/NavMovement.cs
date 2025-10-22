using _01.Code.Stats;
using UnityEngine;
using UnityEngine.AI;

namespace _01.Code.Enemies
{
    public class NavMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float stopOffset = 0.05f; 
        
        private Entities.Entity _entity;
        private StatSO _statCompo;
        private Transform _lookAtTrm;
        
        
        public bool IsArrived => !agent.pathPending && agent.remainingDistance < agent.stoppingDistance + stopOffset;
        public float RemainDistance => agent.pathPending ? -1 : agent.remainingDistance;
        public Vector3 Velocity => agent.velocity;

        public bool UpdateRotation
        {
            get => agent.updateRotation;
            set => agent.updateRotation = value;
        }
        private float _speedMultiplier = 1f;
        public float SpeedMultiplier
        {
            get => _speedMultiplier;
            set
            {
                _speedMultiplier = value;
            }
        }
        
        public void Initialize(Entities.Entity entity)
        {
            _entity = entity;
        }
        
        public void SetLookAtTarget(Transform target)
        {
            _lookAtTrm = target;
            UpdateRotation = target == null; 
        }

        private void Update()
        {
            if (_lookAtTrm != null || (agent.hasPath && agent.isStopped == false))
            {
                LookAtTarget(_lookAtTrm.position);
            }
        }
        
        
        public Quaternion LookAtTarget(Vector2 target)
        {
            float direction = target.x - _entity.transform.position.x;
            float angle = direction > 0 ? 0 : 180;
            Quaternion lookRotation = Quaternion.Euler(0,angle,0);
            _entity.transform.rotation = lookRotation;
            return lookRotation;
        }

        public void SetStop(bool isStop) => agent.isStopped = isStop;
        public void SetVelocity(Vector3 velocity) => agent.velocity = velocity; 
        public void SetSpeed(float speed) => agent.speed = speed;
        public void SetDestination(Vector2 destination) => agent.SetDestination(destination);
        
        

        private Vector3 GetKnockBackEndPoint(Vector3 force)
        {
            Vector3 startPosition = _entity.transform.position + new Vector3(0, 0.5f);
            if (Physics.Raycast(startPosition, force.normalized, out RaycastHit hit, force.magnitude))
            {
                Vector3 hitPoint = hit.point;
                hitPoint.y = _entity.transform.position.y;
                return hitPoint;
            }

            return _entity.transform.position + force;
        }
    }
}