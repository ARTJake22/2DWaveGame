// using UnityEngine;
// using System.Collections;

// public class PlayerController : MonoBehaviour
// {
//     private SpriteRenderer spriteRenderer;
//     private Color originalColor;
//     public Color flashColor = Color.red; // Color to flash
//     public float flashDuration = 0.5f; // Duration of the flash
//     private bool isFlashing = false;

//     private void Start()
//     {
//         spriteRenderer = GetComponent<SpriteRenderer>();
//         originalColor = spriteRenderer.color; // Store the original color
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Snow"))
//         {
//             StartCoroutine(FlashRed());
//         }
//     }

//     private void OnTriggerExit2D(Collider2D other)
//     {
//         if (other.CompareTag("Snow"))
//         {
//             StopAllCoroutines(); // Stop flashing if exiting the snowy area
//             spriteRenderer.color = originalColor; // Reset to original color
//         }
//     }

//     private IEnumerator FlashRed()
//     {
//         if (!isFlashing)
//         {
//             isFlashing = true;
//             spriteRenderer.color = flashColor; // Change to flash color
//             yield return new WaitForSeconds(flashDuration);
//             spriteRenderer.color = originalColor; // Change back to original color
//             isFlashing = false;
//         }
//     }
// }
