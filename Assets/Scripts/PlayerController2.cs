using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController2 : MonoBehaviour{


    [SerializeField] AudioSource shootSFX;
	// [SerializeField] float movementX;
    // [SerializeField] float movementY;
	[SerializeField] Rigidbody2D rigid;
    [SerializeField] Collider2D collider2;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPos;
	[SerializeField] float speed = 5.0f;
	[SerializeField] bool isFacingRight;
    
    [SerializeField] Slider healthBar;
    private bool moving = false;
    private float t = 0.0f;

    private bool isShooting;

    [SerializeField] private float shootDelay = .5f;

    [SerializeField] AudioSource hitSrc;
 
    // Start is called before the first frame update
    void Start()
    {
        shootSFX=GetComponent<AudioSource>();
    }


    // Update is called once per frame; good for user input
    void FixedUpdate()
    {
        //Press the Up arrow key to move the RigidBody upwards
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigid.velocity = new Vector2(0.0f, 15.0f);
            moving = true;
            t = 0.0f;
        }

        //Press the Down arrow key to move the RigidBody downwards
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rigid.velocity = new Vector2(0.0f, -15.0f);
            moving = true;
            t = 0.0f;
        }

         //Press the Left arrow key to move the RigidBody leftwards
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(isFacingRight)
                Flip();
            rigid.velocity = new Vector2(-15.0f, 0.0f);
            isFacingRight = false;
            moving = true;
            t = 0.0f;
        }

         //Press the Right arrow key to move the RigidBody rightwards
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if(!isFacingRight)
                Flip();
            rigid.velocity = new Vector2(15.0f, 0.0f);
            isFacingRight=true;
            moving = true;
            t = 0.0f;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            if(isShooting)return;
            shootSFX.Play();//play the shooting audio
            // Fire !!
            Debug.Log("Fire!");
            isShooting = true;

            //Instantiate and shoot
            GameObject b = Instantiate(bullet); 
            b.GetComponent<BulletScript>().StartShoot(isFacingRight);
            b.transform.position = bulletSpawnPos.transform.position;//causes the bullet to spawn in front of player
            Invoke("ResetShoot",shootDelay);

       }

    }

    void Flip()
	{
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;
        isFacingRight = !isFacingRight;
	}

    void ResetShoot()
    {
        isShooting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
        

		if (collision.gameObject.CompareTag("Bullet"))
		{
			Debug.Log("collided with bullet");
            healthBar.GetComponent<HealthBar>().DecreaseHealth(50);
            hitSrc.Play();
            if(healthBar.value <= 0)
            {
                 Destroy(gameObject); 
            }
	 	}
    }


}