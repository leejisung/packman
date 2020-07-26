using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private CircleCollider2D circle2d;
    public LayerMask layerMask;

    public float speed;
    private Vector3 vector;
    private bool canmove = true;

    public int walkcount;
    private int currentwalkcount=0;

    // Start is called before the first frame update
    void Start()
    {
        circle2d = GetComponent<CircleCollider2D>();
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


            RaycastHit2D hit;

            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(vector.x * speed * walkcount, vector.y * speed * walkcount);   //캐릭터가 이동하고자 하는 곳

            circle2d.enabled = false;
            hit = Physics2D.Linecast(start, end, layerMask);
            circle2d.enabled = true;
            Debug.Log(hit.transform);
            if (hit.transform != null)
            {
            
                Debug.Log("rrr");
                break;
            }

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
