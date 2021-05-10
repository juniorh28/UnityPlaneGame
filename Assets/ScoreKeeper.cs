using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text sceneTxt;
    [SerializeField] Text nameTxt;
    [SerializeField] const int SCORE_PER_LEVEL = 5;
    int level;
    int targetScore;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        score = PersistentData.Instance.GetScore();
        DisplayScore();
        DisplayScene();
        DisplayName();
        targetScore = (level - 1) * SCORE_PER_LEVEL;

    }

    public void IncrementScore(int amount)
    {
        if (amount < 0)
            Debug.Log("Invalid; amount may not be less than zero.");
        else
        {
            score += amount;
            PersistentData.Instance.SetScore(score);
        }

        DisplayScore();
        if (score >=  targetScore)
            AdvanceLevel();

    }

    public void IncrementScore()
    {
        IncrementScore(1);
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayScene()
    {
        sceneTxt.text = "Level " + (level-1);
    }

    public void AdvanceLevel()
    {
         SceneManager.LoadScene(level + 1);
    }

    public void DisplayName()
    {
        nameTxt.text = "Welcome, " + PersistentData.Instance.GetName();
    }
}

