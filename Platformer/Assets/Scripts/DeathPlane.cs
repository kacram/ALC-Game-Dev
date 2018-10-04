using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour {

    public bool toggle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PC")
        {
            other.GetComponent<CharicterMove>().HP = 0;
            toggle = true;
        }
        toggle = true;
    }
}
