using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//This is made for the Dragon bullet

public class PlayerAim : MonoBehaviour
{
    public EnemySpawnManager2 spawnManager;

    public Camera cam;

    //private Bullets bulletScript;

    public GameObject activeBullet;
    public GameObject bullet;

    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    void Update()
    {
        if (spawnManager.isGameActive)
        {
            //To make the aim follow the mouse
            float camDis = cam.transform.position.y - transform.position.y;
            Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));
            float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
            float angle = (180 / Mathf.PI) * AngleRad;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }

            //To get the player's click and fire
            if (Input.GetMouseButton(0) && canFire)
            {
                canFire = false;
                activeBullet = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
                //bulletScript = bullet.GetComponent<Bullets>();
            }
        }
    }

    //check if the other bullet isn't in the scene
    public void BulletDestroyed()
    {
        //bulletScript = null;
    }
}


