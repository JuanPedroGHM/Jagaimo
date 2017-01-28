using UnityEngine;

public class HealthSystem :MonoBehaviour
{
    public float health;
	public float maxHealth;

	public void Start(){
		health = maxHealth;
	}

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}