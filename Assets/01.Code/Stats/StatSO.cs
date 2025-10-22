using UnityEngine;

namespace _01.Code.Stats
{
    [System.Serializable]
    public class Stats
    {
        public StatType type;
        public float value;
    }
    public enum StatType
    {
        Health,
        Attack,
        Speed
    }
    [CreateAssetMenu(fileName = "Stat", menuName = "SO/StatSO", order = 1)]
    public class StatSO : ScriptableObject
    {
        public Stats[] stats;
    }
    
}