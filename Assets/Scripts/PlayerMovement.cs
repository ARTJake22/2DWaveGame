using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

	public Camera sceneCamera;
	[SerializeField] private int speed = 5;
	private Vector2 movement;
	private Rigidbody2D rb;
	private Animator animator;
	public Weapon weapon;
	private Vector2 mousePosition;

	private bool collision;

   	[SerializeField] float health, maxHealth = 10f;
    [SerializeField] FloatingHealthBar healthBar;
	void Start()
	{

	}
	void Update()
	{
		ProcessInputs();

	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void OnMovement (InputValue value)
	{
		movement = value.Get<Vector2>();

		if (movement.x != 0 || movement.y != 0)
		{
			animator.SetFloat("X", movement.x);
			animator.SetFloat("Y", movement.y);

			animator.SetBool("IsWalking", true);
		} else {
			animator.SetBool("IsWalking", false);
		}
	}
	
	private void FixedUpdate()
	{
		// No velocity Variant
		// rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

		if(movement.x != 0 || movement.y != 0)
		{
			rb.linearVelocity = movement * speed;
		}
		
	}

	void ProcessInputs()
	{
		mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetMouseButtonDown(0))
		{
			weapon.Fire();
		}
	}

	    
		
	public void TakeDamage(float damageAmount){
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0){
            Die();
        }

    }

    void Die(){
        Destroy(gameObject);
    }




	public void OnTriggerStay2D(Collider2D other)
    {
		switch(other.gameObject.tag){
            case "Enemy":
            TakeDamage(0.1f);
            break;
	}


}
}
