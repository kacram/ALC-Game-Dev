using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoomba : MonoBehaviour {


    public float MoveSpeed;
    public float HP;
    public int pointsToAdd;
    public float Damage;

    public Sprite Walking0;
    public Sprite Walking1;
    public Sprite Walking2;
    public Sprite Walking3;

    public bool Move;

    public Transform WallCheck;
    public Transform FloorCheck;
    public float scale;
    public float knockBack;

    public float WallCheckRadius;
    public LayerMask WhatIsWall;
    public GameObject Coin;
    public int tickDelay;
    private int SpriteIndex;
    public int tick;
    private SpriteRenderer spriteRenderer;

    public bool ground;
    public bool wall;
    public bool MovingRight;
    
    // Use this for initialization
    void Start () {
        scale = transform.localScale.x;
        tick = tickDelay;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void FixedUpdate()
    {
        ground = Physics2D.OverlapCircle(FloorCheck.position, WallCheckRadius, WhatIsWall);
        wall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);
    }

    // Update is called once per frame
    void Update () {

        tick -= 1;
        if (tick <= 0)
        {
            SpriteIndex += 1;
            tick = tickDelay;
            if (SpriteIndex > 3)
            {
                SpriteIndex = 0;
            }
        }

        switch (SpriteIndex)
        {
            case 0:
                spriteRenderer.sprite = Walking0;
                break;
            case 1:
                spriteRenderer.sprite = Walking1;
                break;
            case 2:
                spriteRenderer.sprite = Walking2;
                break;
            case 3:
                spriteRenderer.sprite = Walking3;
                break;
            default:
                spriteRenderer.sprite = Walking0;
                break;
        }

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
            transform.localScale = new Vector3(scale, scale, 1f);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(-scale, scale, 1f);
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
                other.GetComponent<CharicterMove>().hspd += knockBack;
            }
            else
            {
                other.GetComponent<CharicterMove>().hspd -= knockBack;
            }
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, knockBack);
        }
    }
}
