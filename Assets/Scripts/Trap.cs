using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {


	public bool active;
	void Start () {
		active = true;
	}

	void OnTriggerEnter2D(Collider2D col){
	    if (!HasHealthSystem(col) || !active) return;

	    Debug.Log ("Triggerd Trap");
	    SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer> ();
	    sprite.color = new Color (0, 0, 0);

	    col.GetComponentInParent<HealthSystem>().Damage(10);
	    active = false;
	}

    private static bool HasHealthSystem(Collider2D col)
    {
        return (col.GetComponentInParent<HealthSystem>() != null);
    }
}
