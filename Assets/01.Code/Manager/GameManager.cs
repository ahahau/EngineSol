using _01.Code.Buildings.CenterTower;
using UnityEngine;

namespace _01.Code.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GridManager GridManager {get; private set;}
        public TimeManager TimeManager {get; private set;}
        public EnemyManager EnemyManager {get; private set;}
        public BuildingManager BuildingManager {get; private set;}
        
        [field:SerializeField]public GameObject Dome {get; private set;}
        [field:SerializeField]public CenterTower CenterTower {get; private set;}
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            GridManager = GetComponentInChildren<GridManager>();
            TimeManager = GetComponentInChildren<TimeManager>();
            EnemyManager = GetComponentInChildren<EnemyManager>();
            BuildingManager = GetComponentInChildren<BuildingManager>();
            
            GridManager.Initialize();
            TimeManager.Initialize();
            EnemyManager.Initialize();
            //BuildingManager.Initialize();
            
            CenterTower = Instantiate(CenterTower, Vector3.zero, Quaternion.identity);
            Dome = Instantiate(Dome, Vector3.zero, Quaternion.identity);
            CenterTower.Initialize();
        }
    }
}