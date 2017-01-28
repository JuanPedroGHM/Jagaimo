using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemyOnHit : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        //hits the body of the enemy but need to kill the parent
        if (other.gameObject.GetComponentInParent<Enemy>() == null) return;
        other.gameObject.GetComponentInParent<Enemy>().HealthSys.Damage(10000000000);
    }
}
