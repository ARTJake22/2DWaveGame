// using UnityEngine;

// public class RockSpawner : MonoBehaviour
// {
//     public GameObject rockPrefab; // The rock prefab to spawn
//     public float spawnDelay = 2f; // Delay between spawns
//     private GameObject[] spawnPoints; // Array to hold spawn points

//     private void Start()
//     {
//         // Find all GameObjects tagged as "SpawnPoint"
//         spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
//         Debug.Log($"Number of spawn points: {spawnPoints.Length}");

//         // Start the spawning process
//         if (spawnPoints.Length > 0)
//         {
//             InvokeRepeating(nameof(SpawnRock), 0f, spawnDelay);
//         }
//         else
//         {
//             Debug.LogWarning("No spawn points found! Please ensure you have GameObjects tagged as 'SpawnPoint'.");
//         }
//     }

//     private void SpawnRock()
//     {
//         // Choose a random spawn point from the array
//         int randomIndex = Random.Range(0, spawnPoints.Length);
//         Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;

//         // Instantiate the rock prefab at the chosen spawn position
//         Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
//         Debug.Log($"Spawned rock at: {spawnPosition}");
//     }
// }




