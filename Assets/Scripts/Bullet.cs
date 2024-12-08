using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag){
            case "MapObjects":
            Destroy(gameObject);
            break;

            case "Enemy":
            other.gameObject.GetComponent<Enemy>().TakeDamage(1);
            Destroy(gameObject);
            break;
        }
    }

}
