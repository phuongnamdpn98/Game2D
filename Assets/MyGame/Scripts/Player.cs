using UnityEngine;
[AddComponentMenu("DangNam/Player")]
public class Player : MonoBehaviour, ICanTakeDamage
{
    public int MaxHealth = 100;
    private int currentHealth;
    public bool isDead = false;
    private float timeDelay = 1f;

    void Start()
    {
        currentHealth = MaxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount, Vector2 hitPhoint, GameObject hitDirection)
    {
        if(isDead) return;
        currentHealth -= damageAmount;
        if(currentHealth <= 0 )
        {
            currentHealth = 0;
            isDead = true;
            DeadPlayer();
        }
    }

    private void DeadPlayer()
    {
        
    }
}
