using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public SpriteRenderer sprite;

    public float returnDelay = 3f;
    public float shootDelay = 5f;
    public Transform player;
    private bool isReturning = false;
    private bool isBulletActive = false;
    private Vector3 originalPosition;

    //public Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        fireBullet();
      //  sprite.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReturning)
        {
            float speed = 10f;
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Check if the bullet has returned to the player then destroy it
            if (transform.position == player.position)
            {
                Destroy(gameObject);
            }
            //sprite.flipX = false;
            //void flipSprite();
        }
    }
    

    void fireBullet()
    {
        if (isBulletActive == false)
        {
            isBulletActive = true;
            //bullet will fire
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            rb = GetComponent<Rigidbody2D>();
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;
            Vector3 rotation = transform.position - mousePos;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

            // Make the bullet come back
            originalPosition = transform.position;
            GameObject playerObject = GameObject.FindWithTag("Player");

            if (playerObject != null)
            {
                player = playerObject.transform;
            }

            StartCoroutine(ReturnAfterDelay());
            StartCoroutine(BulletDelay());
        }
    }

    IEnumerator ReturnAfterDelay()
    {
        // Wait for a delay before returning the bullet
        yield return new WaitForSeconds(returnDelay);
        isReturning = true;
        rb.velocity = Vector3.zero;
    }
    IEnumerator BulletDelay()
    {
        // Wait for a delay before shooting again
        yield return new WaitForSeconds(shootDelay);
        isBulletActive = false;
    }

    //void FlipSprite()
    //{
    //    if (transform.position.x < player.position.x)
    //    {
    //        // Sprite is moving towards the negative x-axis, so flip it
    //        transform.localScale = new Vector3(-2f, 2f, 2f);
    //    }
    //}
}
