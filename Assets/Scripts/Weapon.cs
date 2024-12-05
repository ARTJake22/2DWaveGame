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

	void Update()
	{
		transform.position = player.position + offset;
		mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
		Vector2 aimDirection = mousePosition - rb.position;
		float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = aimAngle;
	}

	public void Fire()
	{
		GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
		projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

	}

}
