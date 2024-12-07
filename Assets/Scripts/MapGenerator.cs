// using UnityEngine;
// using UnityEngine.Tilemaps;

// public class MapGenerator : MonoBehaviour
// {
//     public GameObject chunkPrefab; // Reference to the chunk prefab
//     public int chunkWidth = 10; // Width of each chunk
//     public int chunkHeight = 10; // Height of each chunk
//     public int viewDistance = 5; // Number of chunks to generate around the player

//     private Vector3 lastPlayerPosition;
//     private Vector3 playerPosition;
//     private Transform playerTransform;

//     private void Start()
//     {
//         playerTransform = Camera.main.transform; // Assuming the camera follows the player
//         lastPlayerPosition = playerTransform.position;

//         GenerateChunks();
//     }

//     private void Update()
//     {
//         playerPosition = playerTransform.position;

//         // Check if the player has moved enough to generate new chunks
//         if (Vector3.Distance(playerPosition, lastPlayerPosition) >= chunkWidth)
//         {
//             lastPlayerPosition = playerPosition;
//             GenerateChunks();
//         }
//     }

//     private void GenerateChunks()
//     {
//         // Calculate the number of chunks to generate based on the player's position
//         int playerChunkX = Mathf.FloorToInt(playerPosition.x / chunkWidth);
//         int playerChunkY = Mathf.FloorToInt(playerPosition.y / chunkHeight);

//         for (int x = -viewDistance; x <= viewDistance; x++)
//         {
//             for (int y = -viewDistance; y <= viewDistance; y++)
//             {
//                 Vector3 chunkPosition = new Vector3((playerChunkX + x) * chunkWidth, (playerChunkY + y) * chunkHeight, 0);
//                 CreateChunk(chunkPosition);
//             }
//         }
//     }

//     private void CreateChunk(Vector3 position)
//     {
//         // Check if a chunk already exists at this position
//         if (GameObject.Find($"Chunk_{position.x}_{position.y}") == null)
//         {
//             GameObject chunk = Instantiate(chunkPrefab, position, Quaternion.identity);
//             chunk.name = $"Chunk_{position.x}_{position.y}";

//             // Optionally, you can add tile generation logic here
//             // For example, using a Tilemap to fill the chunk with tiles
//         }
//     }
// }

