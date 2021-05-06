using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(20, rigidBody2D.velocity.y);//left and Right movement
        //rigidBody2D.AddForce(new Vector2(20,0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("enemy"))
		{
			Debug.Log("collided with Enemy");
            Destroy(gameObject);
	 	}
    }
	// 	if (controller.GetComponent<HealthKeeper>().returnPHealth() <= 0)
    //     {
	// 		AudioSource.PlayClipAtPoint(audioEx.clip, transform.position);
	// 		Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
	// 		Destroy(gameObject);
	// 	}
	// }
}
