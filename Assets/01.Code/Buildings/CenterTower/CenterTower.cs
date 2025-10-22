using _01.Code.Entities;
using _01.Code.Manager;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _01.Code.Buildings.CenterTower
{
    public class CenterTower : MonoBehaviour, IPlaceable
    {
        public Tile Tile { get; set; }
        public void Initialize()
        {
            Tile = ScriptableObject.CreateInstance<Tile>();
            GameManager.Instance.GridManager.SetTile(Tile, transform.position);
        }

    }
}