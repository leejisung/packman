using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : MonoBehaviour
{
    public Sprite blank;
    private SpriteRenderer spriteRenderer;
    private int change_chance = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && change_chance == 1)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            spriteRenderer.sprite = blank;
            change_chance = 0;
            Gamemanager.instance.feed -= 1;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
