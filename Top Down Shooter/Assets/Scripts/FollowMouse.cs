using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    public Rigidbody2D Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouse = Input.mousePosition;
        transform.localPosition = new Vector3(Player.position.x + mouse.x, Player.position.y + mouse.y,mouse.z);
	}
}
