using UnityEngine;

namespace _01.Code.Buildings
{
    public class BuildingInstall : MonoBehaviour
    {
        public void InstallBuilding(Building building, Vector2 worldPosition)
        {
            Instantiate(building, worldPosition, Quaternion.identity);
        }
    }
}