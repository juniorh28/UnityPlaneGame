using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public GameObject ObjectMusic;
    //public AudioSource menuSong;
    public AudioSource gameSong;

    //public Slider volumeSlider;

    private float MusicVolume = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        MusicVolume = PersistentData.Instance.GetVolume();
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
 
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        Debug.Log("scenename: "+sceneName);
        if (sceneName == "MainMenu") 
        {
            ObjectMusic = GameObject.FindWithTag("MenuSong");
            gameSong = ObjectMusic.GetComponent<AudioSource>();
            gameSong.volume = PersistentData.Instance.GetVolume();
        }
        else if(sceneName == "Game") 
        {
            ObjectMusic = GameObject.FindWithTag("GameMusic");
            gameSong = ObjectMusic.GetComponent<AudioSource>();
            gameSong.volume = PersistentData.Instance.GetVolume();   
        }
        else
        {
            Debug.Log("no audio");
        }

        //set volume
        // MusicVolume = PlayerPrefs.GetFloat("volume"); 
        // audioSource.volume = PersistentData.Instance.GetVolume();
    }

    // Update is called once per frame
    void Update()
    {
        gameSong.volume = PersistentData.Instance.GetVolume();
        //PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    // public void VolumeUpdater(float volume)
    // {
    //     MusicVolume = volume;
    // }

    // public void MusicReset()
    // {
    //     PlayerPrefs.DeleteKey("volume");
    //     audioSource.volume = 1f;
    //     volumeSlider.value = 1f;
    // }
}
