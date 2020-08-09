using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winorlose : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite win;
    public Sprite lose;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.instance.win == 1 && spriteRenderer.sprite != win)
        {
            spriteRenderer.sprite = win;
        }
        if (Gamemanager.instance.win == -1 && spriteRenderer.sprite != win)
        {
            spriteRenderer.sprite = lose;
        }
    }
}
