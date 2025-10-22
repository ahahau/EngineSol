using _01.Code.Entities;
using UnityEngine;

namespace _01.Code.Players.Combat
{
    public abstract class Gun : MonoBehaviour
    {
        [SerializeField] protected Bullet bulletPrefab;
        [SerializeField] protected Transform firePoint;
        [SerializeField] protected EntityAnimator _animator;
        public virtual void Shoot(int damage, float speed, float bulletLifeTime)
        {
            Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.Initialize(damage, speed, bulletLifeTime);
        }
    }
}