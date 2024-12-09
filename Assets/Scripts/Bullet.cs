using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public void OnTriggerEnter2D(Collider2D other) //Running on collisions with mapObjects and Enemies, this allows us to create an event to run code when one of the two happens
    {
        switch(other.gameObject.tag){
            case "MapObjects":
            Destroy(gameObject); //Destroying Bullets on impact with mapObjects
            break;

            case "Enemy":
            other.gameObject.GetComponent<Enemy>().TakeDamage(1); //Calling TakeDamage function from Enemy script in order to deal
            Destroy(gameObject); //Destroying Bullets on impact with Enemies
            break;
        }
    }

}
