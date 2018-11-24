using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float HP;
    public float healthSize;
    public GameObject Player;
	
	// Update is called once per frame
	void Update () {
        HP = Player.GetComponent<CharicterMove>().HP;

        transform.localScale = new Vector3(transform.localScale.x,healthSize * HP);
	}
}
