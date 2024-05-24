using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    //public PlayerAim playerAim;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    private PlayerAim playerScript;
    private PlayerAim2 playerScript2;

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
                //playerScript.BulletDestroyed();
                //playerScript2.BulletDestroyed();
                Destroy(gameObject);
            }
        }
    }


    void fireBullet()
    {
        if (isBulletActive == false)
        {
            isBulletActive = true;

            //playerAim.BulletDestroyed();

            //bullet will fire
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            rb = GetComponent<Rigidbody2D>();
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;
            Vector3 rotation = transform.position - mousePos;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

            if (direction.x > 0)
            {
                sprite.flipX = true;
            }

            // Make the bullet come back
            originalPosition = transform.position;
            GameObject playerObject = GameObject.FindWithTag("Player");

            if (playerObject != null)
            {
                player = playerObject.transform;
                //playerAim.BulletDestroyed();
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
        sprite.flipX = !sprite.flipX;
    }
    IEnumerator BulletDelay()
    {
        // Wait for a delay before shooting again
        yield return new WaitForSeconds(shootDelay);
        isBulletActive = false;
    }
}