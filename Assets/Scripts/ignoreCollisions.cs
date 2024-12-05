using UnityEngine;

public class ignoreCollisions : MonoBehaviour
{


    public GameObject player;
    public GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>(), true);
	}

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>(), true);
    }
}
