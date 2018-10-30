using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Transform FirePoint;
    public Transform PC;
    public float Speed;

	// Use this for initialization
	void Start () {
        Speed = Speed * Mathf.Sign(PC.transform.localScale.x);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed,0f);
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
}
