using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//This is made for the Dragon bullet

public class PlayerAim : MonoBehaviour
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

      if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        //To get the player's click and fire
      if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }

        //If it finds the monster it likes to eat
       //if (collision.CompareTag("Enemy"))
       // {
       //     Destroy(gameObject);
       //}
    }




    //    private Transform aimTransform;
    //
    //    private void Awake()
    //    {
    //        aimTransform = transform.Find("Aim");
    //    }
    //
    //    // Update is called once per frame
    //    private void Update()
    //       {
    //        //Vector3 mousePosition = GetMouseWorldPosition();
    //           Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
    //
    //           Vector3 aimDirection = (mousePosition - transform.position).normalized;
    //           float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    //           aimTransform.eulerAngles = new Vector3(0, 0, angle);
    //           Debug.Log(angle);
    //      }
    //
    //get mouse position
    //        public static Vector3 GetMouseWorldPosition()
    //        {
    //            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    //            vec.z = 0f;
    //            return vec;
    //        }
    //       public static Vector3 GetMouseWorldPositionWithZ()
    //        {
    //          return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    //       }
    //       public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    //       {
    //            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    //        }
    //        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    //        {
    //            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
    //           return worldPosition;
}

