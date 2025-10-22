using _01.Code.Buildings;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _01.Code.Manager
{
    public class GridManager : MonoBehaviour
    {
        private Grid _grid;
        private Tilemap _tilemap;
        
        public void Initialize()
        {
            _grid = this.AddComponent<Grid>();
            _tilemap = this.AddComponent<Tilemap>();
        }
        public bool IsCellOccupied(Vector2 worldPosition)
        {
            Vector3Int cellPosition = _grid.WorldToCell(worldPosition);
            TileBase tile = _tilemap.GetTile(cellPosition);
            return tile != null;
        }
        public Vector2 GetCellCenterWorld(Vector2 worldPosition)
        {
            Vector3Int cellPosition = _grid.WorldToCell(worldPosition);
            Vector3 cellCenterWorld = _grid.GetCellCenterWorld(cellPosition);
            return cellCenterWorld;
        }
        public void SetTile(Tile tile, Vector2 worldPosition)
        {
            Vector3Int cellPosition = _grid.WorldToCell(worldPosition);
            _tilemap.SetTile(cellPosition, tile);
        }
        
    }
}