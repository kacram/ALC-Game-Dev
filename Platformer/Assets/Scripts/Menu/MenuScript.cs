using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public int levelToLoad;
    public bool start;
    public bool start2;
    public Sprite running0;
    public Sprite running1;
    public Sprite running2;
    public Sprite running3;
    public Sprite running4;
    public Sprite trip;
    public int tick2;
    public bool begin;

    private SpriteRenderer spriteRenderer;
    private int cSpriteIndex;
    private int tick;
    public int tickDelay;

    private void Start()
    {
        transform.localScale = new Vector3(6f,6f,1f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        tick = tickDelay;
    }

    // Use this for initialization
    public void LoadLevel () {
        start = true;
	}
	
	// Update is called once per frame
	public void LevelExit () {
        Application.Quit();
	}

    private void Update()
    {
        if (begin == true)
        {
            tick2 -= 1;
        }

        if (tick2 <= 0)
        {
            SceneManager.LoadScene(levelToLoad);
        }

        tick -= 1;
        if (tick <= 0)
        {
            cSpriteIndex += 1;
            tick = tickDelay;
        }

        if (cSpriteIndex > 4)
        {
            cSpriteIndex = 0;
        }

        if (start == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(6,0);

            switch (cSpriteIndex)
            {
                case 0:
                    spriteRenderer.sprite = running0;
                break;
                case 1:
                    spriteRenderer.sprite = running1;
                break;
                case 2:
                    spriteRenderer.sprite = running2;
                break;
                case 3:
                    spriteRenderer.sprite = running3;
                break;
                case 4:
                    spriteRenderer.sprite = running4;
                break;
                default:
                    spriteRenderer.sprite = trip;
                break;
                
            }

            if (GetComponent<Rigidbody2D>().position.x >= 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                spriteRenderer.sprite = trip;
                begin = true;
            }
        }
    }
}
