using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject controller;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
            controller = GameObject.FindGameObjectWithTag("GameController");
        if (audio == null)
            audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collided with coin");
            controller.GetComponent<Scorekeeper>().IncrementScore();
            AudioSource.PlayClipAtPoint(audio.clip, transform.position); //figure out if that is the best way of handling audio source/clip
            Destroy(gameObject);


        }
    }
}
