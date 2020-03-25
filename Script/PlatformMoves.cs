using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoves : MonoBehaviour {

    int i = 100;
    public float speed = 4f;
    private Rigidbody2D rb;
    int ran1;
    int ran2;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         ran1 = Mathf.RoundToInt(Random.Range(5, 40));
         ran2 = Mathf.RoundToInt(Random.Range(5, 40));
    }

    // Update is called once per frame
    void Update()
    {
        if(i>99){ rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime/2f+Vector2.up*speed/(ran1)*Time.deltaTime); i++; if (i == 500) { i *= -1; } }
        if(i<0)
        {
           rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime/2f+Vector2.down * speed / (ran2) * Time.deltaTime); i++;
            if (i == -100) { i *= -1; }
        }
        
    }
}

