// using UnityEngine;

// public class PlayerHealth : MonoBehaviour
// {
//     public float health = 5f; // Player's health

//     public void TakeDamage(float damage)
//     {
//         health -= damage; // Reduce health by damage amount
//         Debug.Log("Player Health: " + health);

//         // Check if the player is dead
//         if (health <= 0)
//         {
//             Die();
//         }
//     }

//     void Die()
//     {
//         Debug.Log("Player has died!");
//         // Implement death logic (e.g., restart level, show game over screen, etc.)
//         // For example, you could disable the player GameObject:
//         gameObject.SetActive(false);
//     }
// }
