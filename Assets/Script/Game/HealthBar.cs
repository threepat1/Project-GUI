using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public GameObject heart1, heart2, heart3, heart4, heart5, gameOver;
    public static int health;

    private void Start()
    {
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        heart4.gameObject.SetActive(true);
        heart5.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(health > 5)
        {
            health = 5;

            switch (health)
            {
                case 5:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    heart4.gameObject.SetActive(true);
                    heart5.gameObject.SetActive(true);
                    gameOver.gameObject.SetActive(false);
                    break;
                case 4:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    heart4.gameObject.SetActive(true);
                    heart5.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(false);
                    break;
                case 3:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    heart4.gameObject.SetActive(false);
                    heart5.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(false);
                    break;
                case 2:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    heart5.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(false);
                    break;
                case 1:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    heart5.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(false);
                    break;
                case 0:
                    heart1.gameObject.SetActive(false);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    heart5.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(true);
                    // anime or time.timescale = 0
                    break;
                    
            }
        }

    }

}
