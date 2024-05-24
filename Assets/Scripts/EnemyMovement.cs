using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;

    public float minSpeed = 10f;
    public float maxSpeed = 35f; 

    public string target = "Target";
    public SpriteRenderer sprite;

    public bool isDragon;

    // Start is called before the first frame update
    void Start()
    {
        //Set the random movement speed
        movementSpeed = Random.Range(minSpeed, maxSpeed);

        if (transform.position.x < 0)
        {
            sprite.flipX= true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] targetObject = GameObject.FindGameObjectsWithTag(target);

        //find the target and move towards it
        if (targetObject.Length > 0)
        {
            Transform target = targetObject[0].transform;
            Vector3 direction = (target.position - transform.position);
            transform.Translate((direction * movementSpeed).normalized * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("No objects with tag " + target + " found.");
        }       
    }

    //Destroy the enemy if it reaches the target
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            Destroy(gameObject);
        }
        if(isDragon && collision.CompareTag("DragonBullet"))
        {
            Destroy(gameObject);
        }
        if(!isDragon && collision.CompareTag("CatBullet"))
        {
            Destroy(gameObject);
        }

        //if (collision.CompareTag("Squirrel"))
        //{
        //    Destroy(gameObject);
        //}
        //if (collision.CompareTag("Dragon"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
