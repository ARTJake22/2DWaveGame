// using UnityEngine;

// public class Rock : MonoBehaviour
// {
//     public float damage = 1f; // Amount of damage the rock does

//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         // Check if the collided object has the "Player" tag
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             // Get the PlayerHealth component and apply damage
//             PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
//             if (playerHealth != null)
//             {
//                 playerHealth.TakeDamage(damage);
//             }

//             // Destroy the rock after it hits the player
//             Destroy(gameObject);
//         }
//     }
// }
