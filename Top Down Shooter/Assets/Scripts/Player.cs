using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D Mouse;

    //keybinds
    public KeyCode keyUp;
    public KeyCode KeyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;

    //game vars
    private float hSpeed;
    private float vSpeed;
    public bool pressed;

    //constants
    public float speed;
    public GameObject Projectile;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        Vector3 mouse = Mouse.position;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg);

        move();
        fire();
    }

    private void move()
    {
        if (Input.GetKey(keyUp))
        {
            vSpeed += speed;
            pressed = true;
        }
        if (Input.GetKey(KeyDown))
        {
            vSpeed -= speed;
        }
        if (Input.GetKey(keyLeft))
        {
            hSpeed -= speed;
        }
        if (Input.GetKey(keyRight))
        {
            hSpeed += speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed, vSpeed);

        hSpeed = 0;
        vSpeed = 0;
    }

    private void fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Projectile);
        }
    }
}
