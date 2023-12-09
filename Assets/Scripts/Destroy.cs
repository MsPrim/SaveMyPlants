using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;   //ignore collision

public class Destroy : MonoBehaviour
{
    public TreeHealth treeHealth;   //call upon the tree health script
    public int health = 10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            {
            Debug.Log("Collision detected");

            Destroy(collision.gameObject);

            treeHealth.health--; 

            if(treeHealth.health <= 0)
                {

                }
            else
                {

                }
             }
    }

    //IEnumerator beInvincible()
    //{
    //    Physics2D.IgnoreLayerCollision();
    //}

}
