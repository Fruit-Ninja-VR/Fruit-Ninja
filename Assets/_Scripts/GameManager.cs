using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("Lives left: "+this.lives);
        
    }
}
