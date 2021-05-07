using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    [SerializeField] GameObject PauseScreen;
    public static bool gameIsPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    public void PauseGame ()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            PauseScreen.SetActive(true);
        }
        else 
        {
            UnpauseGame();
        }
    }
    public void UnpauseGame()
    {

        Time.timeScale = 1;
        PauseScreen.SetActive(false);
    }
}