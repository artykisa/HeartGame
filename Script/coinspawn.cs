using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinspawn : MonoBehaviour
{
    public GameObject objchar;
    public GameObject crystal;
    public GameObject BOnus_1;
    int rand1, rand2, choose;
    int i;

    // Use this for initialization
    void Start()
    {
        i = 50;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            rand1 = Random.Range(-4, 4);
            rand2 = Random.Range(-10, 10);
            choose = Random.Range(0, 10);
            if (choose == 7)
            {
                Instantiate(crystal, new Vector2(rand2, rand1), transform.rotation);
            }
            else if (choose == 8)
            {
                Instantiate(BOnus_1, new Vector2(rand2, rand1), transform.rotation);
            }
            else
            {
                
                Instantiate(objchar, new Vector2(rand2, rand1), transform.rotation);
            }
        }
        i++;
        if (i == 150) { i *= 0; }
    }
}
