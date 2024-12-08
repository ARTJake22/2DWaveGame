using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField] float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] FloatingHealthBar healthBar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        target = GameObject.Find("Player").transform;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }
    
    private void FixedUpdate()
    {
        if (target)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
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
}
