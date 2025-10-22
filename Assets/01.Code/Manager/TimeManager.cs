using System;
using UnityEngine;

namespace _01.Code.Manager
{
    public class TimeManager : MonoBehaviour
    {
        public bool IsNightTime { get; private set; }
        private float CurrentHour= 0;
        
        [field: SerializeField] public int DayTimeHour { get; private set; } = 120;

        [SerializeField] private bool _runTime = false;
        public void Initialize()
        {
            IsNightTime = false;
        }

        private void Update()
        {
            if (!IsNightTime) return;
            CurrentHour += Time.deltaTime;
            if (CurrentHour >= DayTimeHour)
            {
                CurrentHour = 0;
                IsNightTime = true;
                GameManager.Instance.EnemyManager.SpawnEnemies();
            }
        }
    }
}