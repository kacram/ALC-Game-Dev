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
	void Update () {
        transform.localPosition = new Vector3(transform.localPosition.x + XOffset,transform.localPosition.y + YOffset,transform.localPosition.y + ZOffset);
	}
}
