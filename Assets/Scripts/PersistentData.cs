using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] float musicVolume = 1f;
    public static PersistentData Instance;

    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;
    }

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetScore(int score)
    {
        playerScore = score;
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }
    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public float GetVolume()
    {
        return musicVolume;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
