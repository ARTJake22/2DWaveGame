// using UnityEngine;
// using UnityEngine.Tilemaps;

// public class TileObjectPlacer : MonoBehaviour
// {
//     public Tilemap tilemap; // Reference to your Tilemap
//     public GameObject objectPrefab; // The prefab to place on the tiles

//     // Call this method to place objects
//     public void PlaceObjectsOnTiles(Vector3Int[] tilePositions)
//     {
//         foreach (Vector3Int position in tilePositions)
//         {
//             // Check if the tile at the position is not null
//             if (tilemap.GetTile(position) != null)
//             {
//                 // Instantiate the object at the tile's position
//                 Vector3 worldPosition = tilemap.GetCellCenterWorld(position);
//                 Instantiate(objectPrefab, worldPosition, Quaternion.identity);
//             }
//         }
//     }
// }
