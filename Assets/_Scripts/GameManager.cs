using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject[] hearts;

    [SerializeField]
    public GameObject gameOver;

    private int score = 0;
    private int lives = 3;

    void Start()
    {
        // Sets the game over menu to false once the game starts
       gameOver.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(lives < 1) {
            Destroy(hearts[0].gameObject);
        } else if(lives < 2) {
            Destroy(hearts[1].gameObject);
        } else if(lives < 3) {
            Destroy(hearts[2].gameObject);
        }
    }

    public void SetScore(int score) 
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }

    public void Bombed()
    {
        // Decrease 1 life on each bomb hit
        this.lives--;
        Debug.Log("Lives left: " + this.lives);

        if(this.lives <=0)
        {
            gameOver.SetActive(true);
        }
    }

    public int GetLives()
    {
        return this.lives;
    }
}
