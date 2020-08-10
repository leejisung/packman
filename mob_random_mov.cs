using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob_random_mov : MonoBehaviour
{
    private CircleCollider2D circle2d;
    private Animator animator;
    public LayerMask layerMask;

    public float speed;
    public int walkcount;
    private int currentwalkcount = 0;
    private Vector3 vector;

    private bool canmove = true;

    // Start is called before the first frame update
    void Start()
    {
        circle2d = GetComponent<CircleCollider2D>();
        move_direction();

        movement(1);
        movement(4);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Gamemanager.instance.win -= 1;
        }
    }

    IEnumerator movec(int direction)
    {
        if (direction == 1)//up
        {
            vector = new Vector3(0, 1.0f, 0);
        }
        if (direction == 2)//down
        {
            vector = new Vector3(0, -1.0f, 0);
        }
        if (direction == 3)//right
        {
            vector = new Vector3(1.0f, 0, 0);
        }
        if (direction == 4)//left
        {
            vector = new Vector3(-1.0f, 0, 0);
        }
        while (walkcount > currentwalkcount)
        {

            transform.Translate(vector.x * speed, vector.y * speed, 0);
            currentwalkcount++;
            yield return new WaitForSeconds(.01f);

        }
        currentwalkcount = 0;
        canmove = true;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    void movement(int num)
    {
        if (canmove==true)
        {
            canmove = false;
            StartCoroutine(movec(num));
        }
        
    }


    void move_direction()
    {
        circle2d.enabled = false;
        Vector2 start = transform.position;

        RaycastHit2D up_hit;
        Vector2 end = start + new Vector2(0, 2.6f);
        up_hit = Physics2D.Linecast(start, end, layerMask);

        RaycastHit2D down_hit;
        end = start + new Vector2(0, -2.6f);
        down_hit = Physics2D.Linecast(start, end, layerMask);

        RaycastHit2D right_hit;
        end = start + new Vector2(2.6f, 0);
        right_hit = Physics2D.Linecast(start, end, layerMask);

        RaycastHit2D left_hit;
        end = start + new Vector2(-2.6f, 0);
        left_hit = Physics2D.Linecast(start, end, layerMask);

        circle2d.enabled = true;

        Debug.Log(up_hit.transform);
        Debug.Log(down_hit.transform);
        Debug.Log(right_hit.transform);
        Debug.Log(left_hit.transform);
    }

    
}
