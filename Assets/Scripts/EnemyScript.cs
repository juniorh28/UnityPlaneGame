using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int health = 3;

    [SerializeField] float moveSpeed;
    Rigidbody2D rigidbody;
    private bool facingRight;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioSource hitSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        //audioSrc = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //if the player is to the enemy's left and facing right
        //or if the player is to the enemy's right and not facing right
        if(player.transform.position.x < transform.position.x && !facingRight || 
        player.transform.position.x > transform.position.x && facingRight){
            Flip();
        }
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Bullet"))
		{
			Debug.Log("collided with bullet");
            health--; 
            hitSrc.Play();
            if(health <= 0)
            {
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
}
