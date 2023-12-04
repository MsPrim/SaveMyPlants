using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public string target = "Target";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] targetObject = GameObject.FindGameObjectsWithTag(target);

        //find the target and move towards it
        if (targetObject.Length > 0)
        {
            Transform target = targetObject[0].transform;
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("No objects with tag " + target + " found.");
        }

        //Destroy the enemy if it reaches the target
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Target"))
            {
                Destroy(gameObject);
            }
            if (other.CompareTag("Squirrel"))
            {
                Destroy(gameObject);
            }
            if (other.CompareTag("Dragon"))
            {
                Destroy(gameObject);
            }
        }
    }
}
