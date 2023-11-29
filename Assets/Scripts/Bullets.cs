using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    public float returnDelay = 3f;
    public float shootDelay = 6f;
    public Transform player;
    private bool isReturning = false;
    private bool isBulletActive = false;
    private Vector3 originalPosition;

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
            float speed = 4f;
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Check if the bullet has returned to the player then destroy it
            if (transform.position == player.position)
            {
                Destroy(gameObject);
            }
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

            //rotate the bullet
            //float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    IEnumerator ReturnAfterDelay()
    {
        // Wait for a delay before returning the bullet
        yield return new WaitForSeconds(returnDelay);
        isReturning = true;
    }
    IEnumerator BulletDelay()
    {
        // Wait for a delay before shooting again
        yield return new WaitForSeconds(shootDelay);
        isBulletActive = false;
}
}
