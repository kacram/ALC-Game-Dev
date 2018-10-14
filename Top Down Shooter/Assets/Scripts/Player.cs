using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D Mouse;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouse = Mouse.position;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(mouse.y - transform.position.y,mouse.x - transform.position.x) * Mathf.Rad2Deg);
    }
}
