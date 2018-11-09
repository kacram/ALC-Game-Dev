﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int pointsToAdd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Rigidbody2D>() == null)
            return;

        if (other.name == "PC")
        {
            ScoreManager.AddPoints(pointsToAdd);

            Destroy(gameObject);
        }
    }
}
