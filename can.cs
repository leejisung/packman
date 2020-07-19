using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : MonoBehaviour
{
    public Sprite blank;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag =="Player")
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            spriteRenderer.sprite = blank;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
