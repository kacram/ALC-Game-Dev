using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    //keybinds
    public KeyCode Foreward;
    public KeyCode Left;
    public KeyCode Right;

    //Constants
    public float Acceleration;
    public float MaxSpeed;
    public float TurningSpeed;

    //Variables
    private float velocity;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    //move the player
    public void Move()
    {
        if (Input.GetKey(Foreward))
        {
            velocity += Acceleration;
        }
        if (Input.GetKey(Right))
        {
            GetComponent<Rigidbody>().AddTorque(transform.right * TurningSpeed);
        }
        if (Input.GetKey(Left))
        {
            GetComponent<Rigidbody>().AddTorque(transform.right * -TurningSpeed);
        }
        if (velocity > MaxSpeed)
        {
            velocity = MaxSpeed;
        }
        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x + (velocity * Mathf.Cos(GetComponent<Rigidbody>().rotation.y)), GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.x + (velocity * Mathf.Sin(GetComponent<Rigidbody>().rotation.y)));
    }
}
