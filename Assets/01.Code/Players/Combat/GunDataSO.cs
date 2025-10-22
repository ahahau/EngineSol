using UnityEngine;

namespace _01.Code.Players.Combat
{
    [CreateAssetMenu(fileName = "GunData", menuName = "SO/Gun", order = 0)]
    public class GunDataSO : ScriptableObject
    {
        [field:SerializeField] public Gun Prefab { get; private set; }
        [field:SerializeField] public float FireRate { get; private set; } = 0.2f;
        [field:SerializeField] public float BulletSpeed { get; private set; } = 20f;
        [field:SerializeField] public int Damage { get; private set; } = 10;
        [field:SerializeField] public int MaxAmmo{ get; private set; } = 30;
        [field:SerializeField] public float ReloadTime{ get; private set; } = 1.5f;
        [field:SerializeField] public float BulletLifeTime{ get; private set; } = 3f;
        [field:SerializeField] public bool IsAutomatic{ get; private set; } = true;
    }
}