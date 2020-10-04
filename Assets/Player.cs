using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject gameOver;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public TimerScript t;

    private bool invincible = false;

    private float finnishTime;

    public GameObject deadPrefab;

    void Start()
    {
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
    }

    void Update()
    {
        if (health == 2)
        {
            heart3.gameObject.SetActive(false);
        }

        if (health == 1)
        {
            heart2.gameObject.SetActive(false);
        }

        if (health == 0)
        {
            heart1.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);

            t.Finnished();

            finnishTime = t.t;
            Stars();

            gameObject.SetActive(false);
            GameObject dead = Instantiate(deadPrefab);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!invincible)
        {

            if (other.tag == "Slime")
            {
                health -= 1;
                invincible = true;
                Invoke("resetInvulnerability", 2);

            }
        }
    }

    void resetInvulnerability()
    {
        invincible = false;
    }

    private void Stars()
    {
        if (finnishTime < 20.0f)
        {
            return;

        }else if(finnishTime < 40.0f)
        {
            star1.gameObject.SetActive(true);

        }else if(finnishTime < 60.0f)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);

        }else if(finnishTime > 60.0f)
        {
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
        }



    }
}
