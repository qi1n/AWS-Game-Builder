using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int initHealth = 3;

    private int currentHealth;

    private void Start()
    {
        currentHealth = initHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
