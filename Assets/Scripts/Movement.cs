using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	float xinput;
	float yinput;
	Rigidbody2D myrb;
	Vector2 velocity;
	public float speed;
	// Use this for initialization
	void Start () {
		myrb = gameObject.GetComponent<Rigidbody2D> ();
		velocity = Vector2.zero;
	}
	void Update(){
		xinput = Input.GetAxis ("Horizontal");
		yinput = Input.GetAxis ("Vertical");
	}
	// Update is called once per frame
	void FixedUpdate () {
		velocity.x = xinput;
		velocity.y = yinput;
		velocity.Normalize ();
		velocity *= speed;

		myrb.velocity = velocity;
	}
}
