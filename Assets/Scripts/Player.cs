﻿using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Enemy> _enemiesInTrigger;
    public HealthSystem HealthSystem;
	public Sword sword;
    void Start()
    {
        _enemiesInTrigger = new List<Enemy>();
		sword = FindObjectOfType<Sword>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {

			sword._animator.SetTrigger ("attack");
            foreach (var enemy in _enemiesInTrigger)
            {
                if (enemy == null)
                {
                    _enemiesInTrigger.Remove(enemy);
                    return;
                }
				enemy.HealthSystem.Damage(sword.SwordDamage);
            }
        }
    }
}