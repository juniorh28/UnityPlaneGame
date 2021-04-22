using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text sceneTxt;
    [SerializeField] const int SCORE_PER_LEVEL = 1;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        DisplayScore();
        DisplayScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore(int amount)
    {
        if (amount < 0)
            Debug.Log("Invalid; amount may not be less than zero.");
        else
            score += amount;

        DisplayScore();
        if(score >= SCORE_PER_LEVEL)
            AdvanceLevel();
    }

    public void IncrementScore()
    {
        IncrementScore(1);
    }

    public void DisplayScore(){
        scoreTxt.text = "Score: " + score; 
    } 

    public void DisplayScene(){
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log(level);
        sceneTxt.text = "Level "+ level;
    }

    public void AdvanceLevel(){
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel + 1);
    }
}
