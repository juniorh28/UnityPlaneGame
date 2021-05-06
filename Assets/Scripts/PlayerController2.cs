using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour{


	[SerializeField] float movementX;
    [SerializeField] float movementY;
	[SerializeField] Rigidbody2D rigid;
    [SerializeField] Collider2D collider2;
	[SerializeField] float speed = 5.0f;
	[SerializeField] bool isFacingRight = true;
    Object bulletRef;
    private bool moving = false;
    private float t = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("Bullet");
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame; good for user input
    void Update()
    {
		movementX = Input.GetAxis("Horizontal");
        //Debug.Log("MovementX: "+ movementX);
        movementY = Input.GetAxis("Vertical");
        //Debug.Log("MovementY: "+ movementY);
        //Vector2 movement = new Vector2(movementX, movementY);
        //rigid.AddForce(movement * speed);

        //Press the Up arrow key to move the RigidBody upwards
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigid.velocity = new Vector2(0.0f, 15.0f);
            moving = true;
            t = 0.0f;
        }

        //Press the Down arrow key to move the RigidBody downwards
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigid.velocity = new Vector2(0.0f, -15.0f);
            moving = true;
            t = 0.0f;
        }

         //Press the Left arrow key to move the RigidBody leftwards
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.velocity = new Vector2(-15.0f, 0.0f);
            moving = true;
            t = 0.0f;
        }

         //Press the Right arrow key to move the RigidBody rightwards
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.velocity = new Vector2(15.0f, 0.0f);
            moving = true;
            t = 0.0f;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            // Fire !!
            Debug.Log("Fire!");
            GameObject bullet = (GameObject)Instantiate(bulletRef);
            bullet.transform.position = new Vector3(transform.position.x + 7.5f, transform.position.y + .2f, -1);
        }

    }

    //called potentially multiple times per frame, best for physics for smooth behavior
    void FixedUpdate()
	{
		//rigid.velocity = new Vector2(movementY * speed, rigid.velocity.x);//Up and down movement
       // rigid.velocity = new Vector2(movementX * speed, rigid.velocity.y);//left and Right movement
		// Vector2 movement = new Vector2(movementX, movementY);
        // rigid.AddForce(movement * speed);
        if (movementX < 0 && isFacingRight || movementX > 0 && !isFacingRight)
			Flip();

	}

        void Flip()
	{
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;

        //transform.Rotate(0, 180, 0);

        isFacingRight = !isFacingRight;
	}
	// private void OnTriggerEnter2D(Collider2D collision)
	// {
	// 	if (collision.gameObject.tag == "EnemyBullet")
	// 	{
	// 		Debug.Log("collided with EnemyBullet");
	// 	}
	// 	if (controller.GetComponent<HealthKeeper>().returnPHealth() <= 0)
    //     {
	// 		AudioSource.PlayClipAtPoint(audioEx.clip, transform.position);
	// 		Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
	// 		Destroy(gameObject);
	// 	}
	// }


}