using Unity.VisualScripting;
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
	
	//Runs ProcessInputs() at every frame.
	void Update()
	{
		ProcessInputs();

	}


//Gets animator and rigidbody2D component for this gameObject in order to animate and allow movement 
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}


//Takes in movement vectors for player movement and also creates a bool later to be used for walking animations.
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
	

	//Allows movement (added velocity using .linearVelocity)
	private void FixedUpdate()
	{
		// No velocity Variant
		// rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

		if(movement.x != 0 || movement.y != 0)
		{
			rb.linearVelocity = movement * speed;
		}
		
	}


//Processes mouse position when the mouse is on screen, also calls Fire() when mouse is clicked, in order to fire a bullet
	void ProcessInputs()
	{
		mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetMouseButtonDown(0))
		{
			weapon.Fire();
		}
	}

	    
//Makes the player TakeDamage, will be called upon when in contact with an enemy, kills the player when health is 0 or below.
	public void TakeDamage(float damageAmount){
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0){
            Die();
        }

    }


//Kills the player (to be called usually when player health is 0 or below)
    void Die(){
        Destroy(gameObject);
    }



//Makes the enemy take damage as long as the enemy is in contact with it.
	public void OnTriggerStay2D(Collider2D other)
    {
		switch(other.gameObject.tag){
            case "Enemy":
            TakeDamage(0.1f);
            break;
	}


}
}
