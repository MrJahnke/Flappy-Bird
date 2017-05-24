using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

	public void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.GetComponent<Bird> () != null) 
		{
			GameControl.instance.BirdScored();
		}
	}
}
