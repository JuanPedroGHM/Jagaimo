using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public float SwordDamage;
	public Animator _animator;

	void Start(){
		_animator = GetComponent<Animator> ();
	}
}
