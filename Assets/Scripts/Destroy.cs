using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;   //ignore collision
using TMPro;

//This script 

public class Destroy : MonoBehaviour
{
    public EnemySpawnManager spawnManager;

    public TextMeshProUGUI gameOverText;

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
                spawnManager.GameOver();
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
