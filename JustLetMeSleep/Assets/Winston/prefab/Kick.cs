using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown ("k")) 
		{
			anim.Play ("SleepKick");
		}

		if (Input.GetKeyDown ("j")) 
		{

			anim.Play ("Punch");
		}
	}
}
