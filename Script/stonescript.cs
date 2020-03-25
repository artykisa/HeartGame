using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class stonescript : MonoBehaviour {
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
         rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        System.Threading.Thread.Sleep(3000);
      

        rb.MovePosition(new Vector2(Random.Range(800,1000), Random.Range(800, 1000)));
    }
}
