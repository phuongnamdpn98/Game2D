using System;
using UnityEngine;

public class Enemy : MonoBehaviour, ICanTakeDamage
{
    [Header("Enemy Settings")]
    public float maxHealth = 100f;
    private float currentHealth;
    private bool isDead = false;
    private Rigidbody2D rb;
    private float timeDestroy = 0.2f;
    public float nextAttack;
    public float attackRate = 1f;
    public int damagePlayer = 20;
    private EnemyAI enemyAI;

    public void TakeDamage(int damageAmount, Vector2 hitPoint, GameObject hitDirection)
    {
        if (isDead) return;
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        rb.linearVelocity = Vector2.zero;
        enemyAI.enabled = false;
        Destroy(gameObject, timeDestroy);
    }

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Player>().isDead == false)
            {
                collision.GetComponent<Player>().TakeDamage(20, transform.position, gameObject);
                if (Time.time >= nextAttack)
                {
                    nextAttack = Time.time + attackRate;
                    ICanTakeDamage damageable = collision.GetComponent<ICanTakeDamage>();
                    if (damageable != null)
                    {
                        damageable.TakeDamage(damagePlayer, Vector2.right, gameObject);
                    }
                }
            }
        }
    }
}
