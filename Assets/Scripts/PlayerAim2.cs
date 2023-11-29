using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is made for the bear bullet

public class PlayerAim2 : MonoBehaviour
{
    public Camera cam;

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    void Update()
    {
        //To make the aim follow the mouse
        float camDis = cam.transform.position.y - transform.position.y;
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));
        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.Log(angle);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        //To get the player's right click and fire
        if (Input.GetMouseButton(1) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
