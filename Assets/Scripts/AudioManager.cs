using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{

    public GameObject ObjectMusic;
    public AudioSource audioSource;

    public Slider volumeSlider;

    private float MusicVolume = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        audioSource = ObjectMusic.GetComponent<AudioSource>();

        //set volume
        MusicVolume = PlayerPrefs.GetFloat("volume"); 
        audioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void VolumeUpdater(float volume)
    {
        MusicVolume = volume;
    }

    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        audioSource.volume = 1f;
        volumeSlider.value = 1f;
    }
}
