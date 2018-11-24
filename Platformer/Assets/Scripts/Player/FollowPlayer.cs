using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform playerLocation;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(playerLocation.position.x + offsetX, playerLocation.position.y + offsetY, offsetZ);
	}
}
