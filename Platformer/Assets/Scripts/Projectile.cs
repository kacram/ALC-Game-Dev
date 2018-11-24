using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public GameObject FirePoint;
    public GameObject PC;
    public float Speed;
    public float LifeTime;

	// Use this for initialization
	void Start () {


        PC = GameObject.Find("PC");
        FirePoint = GameObject.Find("FirePoint");
        Speed = Speed * Mathf.Sign(PC.transform.localScale.x) + PC.GetComponent<Rigidbody2D>().velocity.x;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0f);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyGoomba>().HP -= 1;
            Destroy(gameObject);
        }
        if (other.name == "Tile")
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        LifeTime--;
        if (LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
