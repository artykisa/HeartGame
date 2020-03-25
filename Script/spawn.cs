using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {
    public GameObject objchar;
    int rand1, rand2;
    int i;
    
    // Use this for initialization
    void Start () {
         i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            rand1 = Random.Range(-3, 3);
            Instantiate(objchar, new Vector2(-12, rand1), transform.rotation);
        }
        i++;
        if (i == 100) { i *= 0; }
    }
}
