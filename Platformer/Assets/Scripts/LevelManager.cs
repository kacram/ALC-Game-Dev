using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;
    public GameObject playerRespawn;

    private Rigidbody2D PC;

    public float respawnDelay;
    public float gravityStore;

    public int lifePenalty;
	// Use this for initialization
	void Start () {
        PC = FindObjectOfType<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator ResawnPlayerCo()
    {
        Instantiate(playerRespawn, PC.transform.position, PC.transform.rotation);
        SetPlayerDeath();

        PC.GetComponent < Rigidbody2D >().gravityScale = 0f;

        yield return new WaitForSeconds(respawnDelay);

        playerRespawn.GetComponent<Rigidbody2D>().gravityScale = gravityStore;

        playerRespawn.transform.position = currentCheckPoint.transform.position;
    }

    public void SetPlayerDeath()
    {

    }
}
