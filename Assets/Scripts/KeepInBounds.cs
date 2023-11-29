using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInBounds : MonoBehaviour
{
    public float xRange = 11.29f;
    public float maxY = 9.6f;
    public float minY = -9.6f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeepPlayerInxBound();
        KeepPlayerInyBound();
    }

    void KeepPlayerInxBound()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
    void KeepPlayerInyBound()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
        transform.position = currentPosition;

        //if (transform.position.y < -yRange)
        //{
        //     transform.position = new Vector2(-yRange, transform.position.x);
        //}
        //if (transform.position.y > yRange)
        //{
        //     transform.position = new Vector2(yRange, transform.position.x);
        //}
    }
}
