using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] float timeToDestroy = 3 ;
    [SerializeField] AudioSource audioSrc;

    Rigidbody2D rigidBody2D;
    //Start is called before the first frame update
    void Start()
    {
        audioSrc=GetComponent<AudioSource>();
    }
    // void FixedUpdate()
    // {
    //     rigidBody2D.velocity = new Vector2(20, rigidBody2D.velocity.y);//left and Right movement
    //     //rigidBody2D.AddForce(new Vector2(20,0));
    // }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("enemy"))
		{
			Debug.Log("collided with Enemy");
            Destroy(gameObject);
            audioSrc.Play();
	 	}
    }
    public void StartShoot(bool isFacingRight)
    {
        Rigidbody2D rigid2D = GetComponent<Rigidbody2D>();
        if(isFacingRight)
        {
            rigid2D.velocity =  new Vector2(speed,0);   //shoot towards right
        }
        else{
            rigid2D.velocity =  new Vector2(-speed,0);  //shoot towards left
        }

        Destroy(gameObject,timeToDestroy);
    }
	// 	if (controller.GetComponent<HealthKeeper>().returnPHealth() <= 0)
    //     {
	// 		AudioSource.PlayClipAtPoint(audioEx.clip, transform.position);
	// 		Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
	// 		Destroy(gameObject);
	// 	}
	// }
}
