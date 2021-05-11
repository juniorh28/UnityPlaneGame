using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public InputField input;
    public Slider musicVolume;
    public void PlayGame()
    {
        PersistentData.Instance.SetName(input.text);
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetName()
    {
        PersistentData.Instance.SetName(input.text);
    }

    public void SetVolume()
    {
         PersistentData.Instance.SetVolume(musicVolume.value);
    }

}
