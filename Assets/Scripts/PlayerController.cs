using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
	public float moveHorizontal;
	public float moveVertical;
	public Rigidbody2D rigid;
	[SerializeField] float speed = 4.0f;
	[SerializeField] bool isFacingRight = true;

	public GameObject bulletToRight, bulletToLeft;
	Vector2 bulletPos;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;

	public AudioSource audio;

	public AudioSource audioEx;
	public GameObject Explosion;

	public GameObject controller;

	// Start is called before the first frame update
	void Start()
	{
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
		if (audio == null)
			audio = GetComponent<AudioSource>();
		if (audioEx == null)
			audioEx = GetComponent<AudioSource>();
		if (controller == null)
			controller = GameObject.FindGameObjectWithTag("GameController");
	}

	// Update is called once per frame; good for user input
	void Update()
	{
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rigid.AddForce(movement * speed);

		if (Input.GetButtonDown("Fire1") && Time.time > nextFire && !EventSystem.current.IsPointerOverGameObject())
		{
			nextFire = Time.time + fireRate;
			fire();
		}

		transform.position = new Vector2(Mathf.Clamp(transform.position.x, -25f, 32f),
			Mathf.Clamp(transform.position.y, -12f, 12f));
	}

	//called potentially multiple times per frame, best for physics for smooth behavior
	void FixedUpdate()
	{
		
		if (moveHorizontal < 0 && isFacingRight || moveHorizontal > 0 && !isFacingRight)
			Flip();
	}

	void Flip()
	{
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;
		isFacingRight = !isFacingRight;
	}

	void fire()
	{
		bulletPos = transform.position;
		if (isFacingRight)
		{
			bulletPos += new Vector2(+1f, -0.43f);
			Instantiate(bulletToRight, bulletPos, Quaternion.identity);
			AudioSource.PlayClipAtPoint(audio.clip, transform.position);
		}
		else
		{
			bulletPos += new Vector2(-1f, -0.43f);
			Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
			AudioSource.PlayClipAtPoint(audio.clip, transform.position);
		}
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