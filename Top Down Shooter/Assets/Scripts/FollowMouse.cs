using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    public Rigidbody2D Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localPosition = new Vector3(mouse.x, mouse.y,0f);
	}
}
