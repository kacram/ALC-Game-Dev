using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public bool NearbyEnemy;
    public GameObject Enemy;
    public int EnemyCheckRadius;
    public LayerMask WhatIsEnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        NearbyEnemy = Physics2D.OverlapCircle(transform.position, EnemyCheckRadius, WhatIsEnemy);

        if (!NearbyEnemy)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
        }
	}
}
