using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField] float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] FloatingHealthBar healthBar;


//Gets the healthbar component from FloatingHealthBar script
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();

    }



    //Updates the healthbar to 100% at the start, also finds the players coordinates
    private void Start()
    {
        target = GameObject.Find("Player").transform;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    
    //changes the direction of the enemy in line with where the player is
    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }
    

//Makes the enemies chase the player according to the moveDirection set above.
    private void FixedUpdate()
    {
        if (target)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }


//Makes the enemy take damage, updates the healthbar accordingly
    public void TakeDamage(float damageAmount){ 
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0){
            Die();   //calls the Die function to kill the enemy if health is 0 or below
        }

    }


//Destroys the enemy gameObject when called
    void Die(){
        Destroy(gameObject);
    }
}
