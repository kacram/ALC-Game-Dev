using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public Rigidbody2D player;
    public Rigidbody2D mouse;

    public float HSpeed;
    public float VSpeed;
    public float MaxSpeed;
    public float angle;

	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(player.position.x,player.position.y,0f);
        angle = Mathf.Atan2(mouse.position.y - player.position.y, mouse.position.x - player.position.x);
        HSpeed = MaxSpeed*Mathf.Cos(angle);
        VSpeed = MaxSpeed*Mathf.Sin(angle);
        GetComponent<Rigidbody2D>().velocity = new Vector2(HSpeed, VSpeed);
        transform.localRotation = new Quaternion (0f,0f,angle,0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
