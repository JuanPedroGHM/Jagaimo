using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour {

	// Use this for initialization
	private Transform parentTransformation;
	private HealthSystem healthSys;
	private SpriteRenderer sprite;
	private Vector3 originalScale;
	void Start () {
		
		parentTransformation = gameObject.GetComponentInParent<Transform> ();
		healthSys = gameObject.GetComponentInParent<HealthSystem> ();
		sprite = gameObject.GetComponent<SpriteRenderer> ();
		originalScale = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, 0, 0);
		gameObject.transform.position = parentTransformation.position;

		float percentage = healthSys.health / healthSys.maxHealth;
		Vector3 scaleVec = new Vector3 (originalScale.x * percentage, originalScale.y, originalScale.z);
		gameObject.transform.localScale = scaleVec;

		if (percentage <= 0.25) {
			sprite.color = new Color (100, 0, 0);
		} else {
			sprite.color = new Color (0, 100, 0);
		}

	}
}
