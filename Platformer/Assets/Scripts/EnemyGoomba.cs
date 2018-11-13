using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoomba : MonoBehaviour {


    public float MoveSpeed;
    public float HP;
    public int pointsToAdd;
    public float Damage;

    public bool Move;

    public Transform WallCheck;
    public Transform FloorCheck;
    public float scale;
    public float knockBack;

    public float WallCheckRadius;
    public LayerMask WhatIsWall;
    public GameObject Coin;

    public bool ground;
    public bool wall;
    public bool MovingRight;
    
    // Use this for initialization
    void Start () {
        scale = transform.localScale.x;
	}

    private void FixedUpdate()
    {
        ground = Physics2D.OverlapCircle(FloorCheck.position, WallCheckRadius, WhatIsWall);
        wall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);
    }

    // Update is called once per frame
    void Update () {

        if (HP <= 0)
        {
            ScoreManager.AddPoints(pointsToAdd);
            Instantiate(Coin, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (wall || !ground)
        {
            MovingRight = !MovingRight;
        }

        if (MovingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(-scale, scale, 1f);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(scale, scale, 1f);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PC")
        {
            other.GetComponent<CharicterMove>().HP -= Damage;
            //knock back
            float PlayerXPos = other.transform.position.x;

            if (PlayerXPos >= transform.position.x)
            {
                other.GetComponent<CharicterMove>().hspd = other.GetComponent<CharicterMove>().MaxSpeed;
            }
            else
            {
                other.GetComponent<CharicterMove>().hspd = -other.GetComponent<CharicterMove>().MaxSpeed;
            }
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, knockBack);
        }
    }
}
