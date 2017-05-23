/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float upForce = 200f;

	private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead == false) 
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2 (0,upForce));
				anim.SetTrigger ("Flap");
			}
		}
	}

	void OnCollisionEnter2D ()
	{
		rb2d.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
	}
}

*/
using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	public float upForce;                   //Upward force of the "flap".
	private bool isDead = false;            //Has the player collided with a wall?

	private Animator anim;                  //Reference to the Animator component.
	private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.

	void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		//Don't allow control if the bird has died.
		if (isDead == false) 
		{
			//Look for input to trigger a "flap".
			if (Input.GetMouseButtonDown(0)) 
			{
				//...tell the animator about it and then...
				anim.SetTrigger("Flap");
				//...zero out the birds current y velocity before...
				rb2d.velocity = Vector2.zero;
				//  new Vector2(rb2d.velocity.x, 0);
				//..giving the bird some upward force.
				rb2d.AddForce(new Vector2(0, upForce));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// Zero out the bird's velocity
		rb2d.velocity = Vector2.zero;
		// If the bird collides with something set it to dead...
		isDead = true;
		//...tell the Animator about it...
		anim.SetTrigger ("Die");
		//...and tell the game control about it.
		GameControl.instance.BirdDied ();
	}
}