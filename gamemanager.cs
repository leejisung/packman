using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public int feed;
    public int win = 0;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (feed==0 && win==0)
        {
            win = 1;
            Debug.Log("win");
        }
        if (win==-1)
        {
            Debug.Log("lose");
        }
    }
}
