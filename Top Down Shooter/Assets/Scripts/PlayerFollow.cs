using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public Transform Player;

    public float XOffset;
    public float YOffset;
    public float ZOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.localPosition = new Vector3(Player.position.x + XOffset, Player.position.y + YOffset, Player.position.z + ZOffset);
	}
}
