using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    private Vector2 StartPos;
    public int ResetTimerTime;
    private int ResetTimer;

	// Use this for initialization
	void Start () {
        StartPos = GetComponent<Rigidbody2D>().position;
        ResetTimer = ResetTimerTime;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,GetComponent<Rigidbody2D>().velocity.y);
        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,0);
        }

        if (GetComponent<Rigidbody2D>().position != StartPos)
        {
            ResetTimer -= 1;
        }

        if (ResetTimer <= 0)
        {
            ResetTimer = ResetTimerTime;
            GetComponent<Rigidbody2D>().position = StartPos;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
	}
}
