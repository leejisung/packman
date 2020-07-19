using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int[,] map = new int[5, 5];
    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i<5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                map[i, j] = 0;
            }
        }

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
