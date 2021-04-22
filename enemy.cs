using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Transform player;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigid.rotation = angle;
        direction.Normalize();
        movement = direction;
        Debug.Log(direction);
    }
    void FixedUpdate(){
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rigid.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
