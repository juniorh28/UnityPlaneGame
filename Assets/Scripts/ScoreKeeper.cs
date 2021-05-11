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
    [SerializeField]  int numOfEnemies = 1;
    int level;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        score = PersistentData.Instance.GetScore();
        DisplayScore();
        DisplayScene();
        DisplayName();
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

    }

    public void IncrementScore()
    {
        IncrementScore(1);
    }

    public void DestroyEnemy()
    {
        numOfEnemies--;
        IncrementScore(10);
        if(numOfEnemies == 0)
        {
            AdvanceLevel();
        }
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
 
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        if (sceneName == "Win")
        {
            return;
        }
        sceneTxt.text = "Level " + (level-2);
    }

    public void AdvanceLevel()
    {
         SceneManager.LoadScene(level + 1);
    }

    public void DisplayName()
    {
        nameTxt.text = "Player: " + PersistentData.Instance.GetName();
    }
}

