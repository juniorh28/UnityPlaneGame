using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Bullet"))
		{
			Debug.Log("collided with bullet");
            health--; 
            if(health <= 0)
            {
                Destroy(gameObject); 
            }
	 	}
    }
}
