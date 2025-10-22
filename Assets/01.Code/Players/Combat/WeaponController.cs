using System.Collections.Generic;
using _01.Code.Entities;
using UnityEngine;

namespace _01.Code.Players.Combat
{
    public class WeaponController : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private Transform gunHolder;
        [SerializeField] private GunDataSO[] gunsData;
        
        private List<Gun> _guns = new List<Gun>();
        public Gun CurrentGun { get; private set; }
        private float _time;
        private Entities.Entity _entity;
        public void Initialize(Entities.Entity entity)
        {
            _entity = entity;
            foreach (var gun in gunsData)
            {
                AddGun(gun);
            }
            EquipGun(0);
        }

        public void NextGun()
        {
            int currentIndex = _guns.IndexOf(CurrentGun);
            int nextIndex = (currentIndex + 1) % _guns.Count;
            EquipGun(nextIndex);
        }

        private void Update()
        {
            _time += Time.deltaTime;
            if (CurrentGun != null)
            {
                LookatMouse();
            }
        }
        private void LookatMouse()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 direction = mousePos - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        private void EquipGun(int i)
        {
            if (CurrentGun != null)
            {
                CurrentGun.gameObject.SetActive(false);
            }
            CurrentGun = _guns[i];
            CurrentGun.gameObject.SetActive(true);
        }
		
        public void AddGun(GunDataSO gunData)
        {
            Gun gun = Instantiate(gunData.Prefab, gunHolder);
            _guns.Add(gun);
            gun.gameObject.SetActive(false);
        }

        public void Shooting()
        {
            if(_time > gunsData[_guns.IndexOf(CurrentGun)].FireRate)
            {
                GunDataSO data = gunsData[_guns.IndexOf(CurrentGun)];
                CurrentGun.Shoot(data.Damage, data.FireRate, data.BulletLifeTime);
                _time = 0;
            }
        }
    }
}