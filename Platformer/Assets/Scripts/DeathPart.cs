using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPart : MonoBehaviour {

    public GameObject PC;

	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 8f);
        PC = FindObjectOfType<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.2f);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PC")
        {
            other.GetComponent<CharicterMove>().Dead = false;
        }
    }
}
