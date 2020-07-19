using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    private Vector3 vector;
    private bool canmove = true;

    public int walkcount;
    private int currentwalkcount=0;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator movec()
    {

        while (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (vector.x !=0)
            {
                vector.y = 0;
            }

            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            while (walkcount > currentwalkcount)
            {

                transform.Translate(vector.x * speed, vector.y * speed, 0);
                currentwalkcount++;
                yield return new WaitForSeconds(.01f);

            }
            currentwalkcount = 0;
        }

        canmove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canmove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canmove = false;
                StartCoroutine(movec());
            }
        }
    }


}
