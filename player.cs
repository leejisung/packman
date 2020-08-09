using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private CircleCollider2D circle2d;
    private Animator animator;
    public LayerMask layerMask;

    public float speed;
    private Vector3 vector;
    private bool canmove = true;

    public int walkcount;
    private int currentwalkcount=0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            if (vector.x == 1)
            {
                this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            if (vector.x==-1)
            {
                this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            if (vector.y == 1)
            {
                this.transform.localScale = new Vector3(1.0f, -1.0f, 1.0f);
            }
            if (vector.y == -1)
            {
                this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }

            Debug.Log(vector.x);
            RaycastHit2D hit;

            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(vector.x * speed * walkcount, vector.y * speed * walkcount);   //캐릭터가 이동하고자 하는 곳

            circle2d.enabled = false;
            hit = Physics2D.Linecast(start, end, layerMask);
            circle2d.enabled = true;
            if (hit.transform != null)
            {
                break;
            }
            animator.SetBool("moving", true);

            if (vector.x != 0)
            {
                animator.SetBool("verticle", false);
            }
            else
            {
                animator.SetBool("verticle", true);
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
        animator.SetBool("moving", false);
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
        if (Gamemanager.instance.win != 0)
        {
            Destroy(gameObject);
        }
    }


}
