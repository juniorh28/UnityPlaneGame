using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] Collider2D collider2;
	[SerializeField] float speed = 10.0f;
	[SerializeField] bool isFacingRight = true;
	 [SerializeField] float velocity = 10;
    [SerializeField] float velocityMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame; good for user input
    void Update()
    {
		// movementX = Input.GetAxis("Horizontal") * speed;
		// movementY = Input.GetAxis("Vertical") * speed;
        // if(Input.GetButtonDown("Jump"))
		// {
		// 	Jump();
		// }
    }

    //called potentially multiple times per frame, best for physics for smooth behavior
    void FixedUpdate()
	{
		rigid.velocity = new Vector2(velocity * velocityMultiplier, rigid.velocity.y);
		if(transform.position.x > 0){
            Flip();
            velocityMultiplier = velocityMultiplier * -1;
        }
        /*
            rigid.velocity = new Vector2(movementX, rigid.velocity.x);
		    if (movementX < 0 && isFacingRight || movementX > 0 && !isFacingRight)
			    Flip();
        */
	}

    void Flip()
	{
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;

       // transform.Rotate(180, 0, 0);

        isFacingRight = !isFacingRight;
	}

    // void Jump()
	// {
	// 	if (isOnGround())
	// 	{
	// 		rigid.velocity = new Vector2(rigid.velocity.x, 0);
	// 		rigid.AddForce(new Vector2(0, jumpForce));
	// 	}
	// }

    // bool isOnGround()
	// {
	// 	Debug.Log("is on ground called");
	// 	Vector2 position = transform.position;
	// 	Vector2 direction = Vector2.down;

	// 	//for debugging purposes only
	// 	Debug.DrawRay(position, direction, Color.green);

	// 	Debug.Log("drew ray");

	// 	RaycastHit2D hit = Physics2D.Raycast(position, direction, groundDistance, whatIsGround);
	// 	if (hit.collider != null)
	// 		grounded = false;
	// 	else
	// 		grounded = true;
	// 	return grounded;
            
	// }
}
