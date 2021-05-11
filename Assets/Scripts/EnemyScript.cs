using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int health = 3;

    [SerializeField] float moveSpeed;
    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] GameObject bullet;
    [SerializeField] private float shootDelay = .5f;
    Rigidbody2D rigidbody;
    private bool facingRight;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioSource hitSrc;
    private bool isShooting;
    public GameObject controller;
    
    // Start is called before the first frame update
    void Start()
    {
        //audioSrc = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("ShootPlayer", 2.0f, shootDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(player){//if the player object exist check ...
            //if the player is to the enemy's left and facing right
            //or if the player is to the enemy's right and not facing right
            if(player.transform.position.x < transform.position.x && !facingRight || 
            player.transform.position.x > transform.position.x && facingRight){
                Flip();
            }
            //move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Bullet"))
		{
			Debug.Log("player shot enemy with bullet");
            health--; 
            Debug.Log("Enemy HP: "+health);
            hitSrc.Play();
            if(health <= 0)
            {
                controller.GetComponent<ScoreKeeper>().DestroyEnemy();
                Destroy(gameObject); 
            }
	 	}
    }

    void Flip()
	{
		Vector3 enemyScale = transform.localScale;
		enemyScale.x = enemyScale.x * -1;
		transform.localScale = enemyScale;
		facingRight = !facingRight;
	}

    void ShootPlayer()
    {
        //if player dont exiat, do not shoot
        if(!player){
            CancelInvoke();
           // return;
        }
        GameObject b = Instantiate(bullet);
        b.GetComponent<BulletScript>().StartShoot(!facingRight);
        b.transform.position = bulletSpawnPos.transform.position;//causes the bullet to spawn in front of player
        Invoke("ResetShoot",shootDelay);
    }

       void ResetShoot()
    {
        isShooting = false;
    }
}

