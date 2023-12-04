using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    float scaleX;

    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //if (movement.x > 0)
        //{
        //    gameObject.transform.localScale = new Vector3(-2, 2, 2);
        //}
        //if (movement.x < 0)
        //{
        //    gameObject.transform.localScale = new Vector3(2, 2, 2);
        //}
    }

    //Called 50 times a second, avoids lag
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
