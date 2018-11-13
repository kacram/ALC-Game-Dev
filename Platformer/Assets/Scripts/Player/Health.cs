using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int HP;
    public GameObject Player;
    public Texture2D HPSprite;
	
	// Update is called once per frame
	void Update () {
        HP =  (int)Player.GetComponent<CharicterMove>().HP;
        for (int i = HP; i < 0; i--)
        {
            Vector2 pos = new Vector2(transform.position.x + 1,transform.position.y + i * 3 + 1);
            Sprite.Create(HPSprite,new Rect(),pos);
        }
	}
}
