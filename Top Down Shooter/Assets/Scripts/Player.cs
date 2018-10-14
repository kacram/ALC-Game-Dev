using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = new Quaternion(0f,0f, 57.2958f * Mathf.Atan2(transform.localPosition.y - Input.mousePosition.y,transform.localPosition.x - Input.mousePosition.x),0f);
	}
}
