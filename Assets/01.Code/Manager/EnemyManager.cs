using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _01.Code.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private int spawnCount = 5;       
        [SerializeField] private float spawnDistance = 8f; 
        [SerializeField] private float randomOffset = 2f;  

        public int enemyCount = 0;

        public void Initialize()
        {
            SpawnEnemies();
        }

        public void SpawnEnemies()
        {
            Vector3 domePos = GameManager.Instance.Dome.transform.position;
            float domeRadius = GameManager.Instance.Dome.transform.localScale.x * 0.5f;

            for (int i = 0; i < spawnCount; i++)
            {
                float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
                float distanceFromDome = domeRadius + spawnDistance + Random.Range(-randomOffset, randomOffset);
                Vector3 dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                Vector3 pos = domePos + dir * distanceFromDome;

                Instantiate(enemy, pos, Quaternion.identity);
                enemyCount++;
            }
        }
    }
}