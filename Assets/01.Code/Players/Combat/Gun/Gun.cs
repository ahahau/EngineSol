using System;
using _01.Code.Entities;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace _01.Code.Players.Combat.Gun
{
    public abstract class Gun : MonoBehaviour
    {
        
        [SerializeField] protected Bullet bulletPrefab;
        [SerializeField] protected Transform firePoint;
        [SerializeField] protected UnityAction ShootFeedback;

        
        private float _shootRate;
        public void Initialize(float shootRate)
        {
            _shootRate = shootRate;
        }
        private void OnEnable()
        {
            ShootFeedback += ShotFeedback;
        }

        private void OnDestroy()
        {
            ShootFeedback -= ShotFeedback;
        }

        public virtual void Shoot(int damage, float speed, float bulletLifeTime)
        {
            //Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            //bullet.Initialize(damage, speed, bulletLifeTime);
            ShotFeedback();
        }
        public virtual void Reload()
        {
               
        }
        protected virtual void ShotFeedback()
        {
            transform.DOMoveX(transform.position.x - 1, _shootRate).SetLoops(2, LoopType.Yoyo);
        }
    }
}