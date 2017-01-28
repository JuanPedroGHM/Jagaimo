using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    public float TimeTillAttack;
    public float AttackDamage;

    private float timeInZone;
    private Animator _animator;
    private Player _player;

    // Use this for initialization
    void Start () {

        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.GetComponent<Player>() == null) return;

        timeInZone += Time.deltaTime;
        if (timeInZone >= TimeTillAttack)
        {
            ExecuteAttack();
            timeInZone = 0;
        }
    }

    private void ExecuteAttack()
    {
        Debug.Log("attack");
        _animator.SetTrigger("attack");
        _player.HealthSystem.Damage(AttackDamage);
    }


	
	
}
