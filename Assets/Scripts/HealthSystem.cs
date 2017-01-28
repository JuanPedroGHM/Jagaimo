using UnityEngine;

public class HealthSystem :MonoBehaviour
{
    public float health;
	public float maxHealth;

	public void Start()
	{
	    SetMaxHealth();
	}

    public void SetMaxHealth()
    {
        health = maxHealth;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}