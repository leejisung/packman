using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob_random_mov : MonoBehaviour
{
    private CircleCollider2D circle2d;
    private Animator animator;
    public LayerMask layerMask;

    public float speed;
    private Vector3 vector;
    private bool canmove = true;

    public int walkcount;
    private int currentwalkcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Gamemanager.instance.win -= 1;
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
