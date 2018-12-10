using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Vector2 Destination0;
    public Vector2 Destination1;

    public bool Oto1;

    public float speed;
    public float distance;
    public float Dir;
    public float Hspeed;
    public float Vspeed;
    public float PlayerSpeedCache;

	// Use this for initialization
	void Start () {
        
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "PC")
        {
            PlayerSpeedCache = other.GetComponent<CharicterMove>().hspd;
            other.GetComponent<CharicterMove>().Ehspd = Hspeed;
        }
    }


    // Update is called once per frame
    void Update () {
        if (Oto1 == true) 
        {
            distance = Mathf.Abs(Vector2.Distance(transform.position,Destination1));
            if (distance > speed/100)
            {
                Dir = Mathf.Atan2(Destination1.y - GetComponent<Rigidbody2D>().transform.position.y, Destination1.x - GetComponent<Rigidbody2D>().transform.position.x);
                Hspeed = speed * Mathf.Cos(Dir);
                Vspeed = speed * Mathf.Sin(Dir);
            }
            else
            {
                GetComponent<Rigidbody2D>().transform.position = new Vector2(Destination1.x, Destination1.y);
                Oto1 = false;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(Hspeed,Vspeed);
        }
        else
        {
            distance = Mathf.Abs(Vector2.Distance(transform.position,Destination0));
            if (distance > speed/100)
            {
                Dir = Mathf.Atan2(Destination0.y - GetComponent<Rigidbody2D>().transform.position.y, Destination0.x - GetComponent<Rigidbody2D>().transform.position.x);
                Hspeed = speed * Mathf.Cos(Dir);
                Vspeed = speed * Mathf.Sin(Dir);
            }
            else
            {
                GetComponent<Rigidbody2D>().transform.position = new Vector2(Destination0.x, Destination0.y);
                Oto1 = true;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(Hspeed, Vspeed);
        }
	}
}
