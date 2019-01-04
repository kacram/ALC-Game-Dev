using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    //set controlls
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    //set constants
    public float Speed;

    //set variables
    public float hspd;
    public float vspd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Move()
    {
        //reset speed variables
        hspd = 0;
        vspd = 0;

        //set speed based on command inputs
        if (Input.GetKey(Up))
        {
            vspd += Speed;
        }
        if (Input.GetKey(Down))
        {
            vspd -= Speed;
        }
        if (Input.GetKey(Left))
        {
            hspd -= Speed;
        }
        if (Input.GetKey(Right))
        {
            hspd += Speed;
        }

        //aply set speed to player rigidbody
        GetComponent<Rigidbody2D>().velocity = new Vector2(hspd, vspd);
    }
}
