using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Camera sceneCamera;
	public GameObject bullet;
	public Transform firePoint;
	public float fireForce;
	private Vector2 mousePosition;
	public Rigidbody2D rb;
	public Transform player;
	public Vector3 offset;


//transforming to player object at every frame, also copying the direction and aim angle
//On this project bullets instantiate from inside the player so this update feature is less relevant
//Accounting for player/bullet collision in the collision matrix
	void Update()
	{
		transform.position = player.position + offset;
		mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
		Vector2 aimDirection = mousePosition - rb.position;
		float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = aimAngle;
	}


//Instantiates a bullet prefab with force at the firePoint coodinates
	public void Fire()
	{
		GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
		projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

	}

}
