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
	[SerializeField] float speed = 15.0f;
	[SerializeField] bool isFacingRight;
    [SerializeField] GameObject healthBar;
    //[SerializeField] Slider healthBar;
    [SerializeField] GameObject score;

    public GameObject Explosion;
    private bool moving = false;
    //public float speed = 15.0f;

    private bool isShooting;

    [SerializeField] private float shootDelay = .5f;

    [SerializeField] AudioSource hitSrc;
 


    // Start is called before the first frame update
    void Start()
    {
        shootSFX=GetComponent<AudioSource>();
        Canvas canvas = FindObjectOfType<Canvas>();
        float h = canvas.GetComponent<RectTransform>().rect.height;
        float w = canvas.GetComponent<RectTransform>().rect.width;
        Debug.Log("canvas width: "+w+" canvas height "+h);
        Vector3 playerPosition= transform.localPosition;
        Debug.Log("player is located in : "+playerPosition);
    }

    void Update()
    {
        ReturnToSceen();
    }


    // Update is called once per frame; good for user input
    void FixedUpdate()
    {
        //Press the Up arrow key to move the RigidBody upwards
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigid.velocity = new Vector2(0.0f, speed);
            moving = true;
        }

        //Press the Down arrow key to move the RigidBody downwards
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rigid.velocity = new Vector2(0.0f, -speed);
            moving = true;
        }

         //Press the Left arrow key to move the RigidBody leftwards
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(isFacingRight)
                Flip();
            rigid.velocity = new Vector2(-speed, 0.0f);
            isFacingRight = false;
            moving = true;
        }

         //Press the Right arrow key to move the RigidBody rightwards
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if(!isFacingRight)
                Flip();
            rigid.velocity = new Vector2(speed, 0.0f);
            isFacingRight=true;
            moving = true;
        }


        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)
        || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)
        || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)
        || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)
        )
        {
            moving = false;
            rigid.velocity = new Vector2(0.0f, 0.0f);
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
            if(healthBar.GetComponent<HealthBar>().GetHealth() <= 0)
            {
                Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
                healthBar.GetComponent<HealthBar>().Death();
            }
	 	}
    }

    public void ReturnToSceen()
    {
            //Flip();
            Vector3 playerPosition = transform.localPosition;
            if(playerPosition.x >= 48)// if the player collide with the right wall
            {
                Debug.Log("collided with canvas");
                Flip();
                playerPosition.x = playerPosition.x  - 2;
                transform.localPosition = playerPosition; 
            }
            if(playerPosition.x <= -48)// if the player collide with the left wall
            {
                Debug.Log("collided with canvas");
                Flip();
                playerPosition.x = playerPosition.x  + 2;
                transform.localPosition = playerPosition; 
            }
            if(playerPosition.y >= 22)// if the player collide with the upper wall
            {
                Debug.Log("collided with canvas");
                playerPosition.y = playerPosition.y  - 2;
                transform.localPosition = playerPosition; 
            }
            if(playerPosition.y <= -22)// if the player collide with the lower wall
            {
                Debug.Log("collided with canvas");
                playerPosition.y = playerPosition.y  + 2;
                transform.localPosition = playerPosition; 
            }  
    }


}