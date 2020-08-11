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
        if (canmove == true)
        {
            int r = move_direction();

            movement(r);
        }
    }
    void movement(int num)
    {
        if (canmove==true)
        {
            canmove = false;
            StartCoroutine(movec(num));
        }
        
    }


    int move_direction()
    {
        int num_arr = 0;
        List<int> move_possible = new List<int>();

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
        
        if (up_hit.transform == null)
        {
            move_possible.Add(1);
            num_arr += 1;
        }
        if (down_hit.transform == null)
        {
            move_possible.Add(2);
            num_arr += 1;
        }
        if (right_hit.transform == null)
        {
            move_possible.Add(3);
            num_arr += 1;
        }
        if (left_hit.transform == null)
        {
            move_possible.Add(4);
            num_arr += 1;
        }

        return move_possible[Random.Range(0, num_arr)];
    }

    
}
