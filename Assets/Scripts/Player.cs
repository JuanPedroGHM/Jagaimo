using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Enemy> _enemiesInTrigger;
	//time when next attack is allowed
	private float nextAttack = 0;

	public float AttacksPerSecond = 0.5f;
    public HealthSystem HealthSystem;
	private Sword _sword;
    void Start()
    {
		_sword = GetComponentInChildren<Sword>();
        _enemiesInTrigger = new List<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemy>() == null) return;
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (_enemiesInTrigger.Contains(enemy)) return;

        _enemiesInTrigger.Add(enemy);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Enemy>() == null) return;
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (!_enemiesInTrigger.Contains(enemy)) return;

        _enemiesInTrigger.Remove(enemy);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)
			&& Time.time > nextAttack)
        {
			Attack();
			nextAttack = Time.time + 1 / AttacksPerSecond;
        }
    }

	private void Attack()
	{
		_sword._animator.Play("Attack");
	    FindObjectOfType<SoundManager>().PlaySound("Player_Slash");
	    _enemiesInTrigger.RemoveAll(t => t == null);
	    foreach (var enemy in _enemiesInTrigger)
		{
			if (enemy == null)return;
			enemy.HealthSys.Damage(_sword.SwordDamage);
		}
	}
}