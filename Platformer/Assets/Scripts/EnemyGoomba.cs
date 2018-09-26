using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoomba : MonoBehaviour {


    public float MoveSpeed;

    public bool Move;

    public Transform WallCheck;
    public Transform FloorCheck;

    public float WallCheckRadius;
    public LayerMask WhatIsWall;

    public bool ground;
    public bool wall;
    public bool MovingRight;
    // Use this for initialization
    void Start () {
		
	}

    private void FixedUpdate()
    {
        ground = Physics2D.OverlapCircle(FloorCheck.position, WallCheckRadius, WhatIsWall);
        wall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);
    }

    // Update is called once per frame
    void Update () {
        if (wall || !ground)
        {
            MovingRight = !MovingRight;
        }

        if (MovingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
	}
}
