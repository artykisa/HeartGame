using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    Color color;
    int coins = 0;
    public GameObject guiTextLink;
    public GameObject HighguiTextLink;
    public GameObject timeguiTextLink;
   public int status = 0, schetchick = 0, bufsch;
    float deltaX, deltaY;


    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
        if (PlayerPrefs.GetInt("HighScore") != 0)
        {
            string opa = PlayerPrefs.GetInt("HighScore").ToString();
            HighguiTextLink.GetComponent<Text>().text = "High Score: " +opa;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
        schetchick++;
        if (schetchick - bufsch == 200)
        {
            schetchick = 0;
            status = 0;
            timeguiTextLink.GetComponent<Text>().text = "";
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;
                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            
            if (collision.gameObject.tag == "Respawn")
            {
                if (status == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    if (coins > PlayerPrefs.GetInt("HighScore"))
                    {
                        PlayerPrefs.SetInt("HighScore", coins);
                    }
                    Application.LoadLevel("menu");
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
        if (collision.gameObject.tag == "Finish")
        {
            coins++;
            guiTextLink.GetComponent<Text>().text = "Score: "+coins;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "crystal")
        {
            coins+=3;
            guiTextLink.GetComponent<Text>().text = "Score: " + coins;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bonus_1")
        {
            status = 1;
            Destroy(collision.gameObject);
            bufsch = schetchick;
                timeguiTextLink.GetComponent<Text>().text = "Rage Mode";
                
            

            
        }
    }
}
