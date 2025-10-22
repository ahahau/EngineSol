using System;
using _01.Code.Buildings;
using Unity.VisualScripting;
using UnityEngine;

namespace _01.Code.Manager
{
    public class BuildingManager : MonoBehaviour
    {
        private BuildingInstall _buildingInstall;
        public bool IsBuildingModeActive { get; private set; }
        public void Initialize()
        {
            _buildingInstall = this.AddComponent<BuildingInstall>();
        }

        public void SetBuildingModeActive(bool active)
        {
            IsBuildingModeActive = active;
        }
    }
}