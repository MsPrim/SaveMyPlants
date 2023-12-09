using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeHealth : MonoBehaviour
{
    public int health;  //Tree's Remaining Health
    public int numOfHearts = 10; //tree's total health

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        health = numOfHearts;
    }

    private void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    //private void UpdateUIHealth()
    //{
    //    for (int i = 0; i < hearts.Length; i++)
    //   {
    //       if (i < health)
    //       {
    //          hearts[i].sprite = fullHeart;
    //      }
    //      else
    //      {
    //          hearts[i].sprite = emptyHeart;
    //      }
    //
    //      if (i < numOfHearts)
    //      {
    //          hearts[i].enabled = true;
    //      }
    //      else
    //      {
    //          hearts[i].enabled = false;
    //      }
    //  }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //   if (collision.CompareTag("Enemy"))
    //    {
    //        Damage(-1);
    //    }
    //}

    // Function to decrease tree health
    //public void Damage(int damageAmount)
    //{
    //    health -= damageAmount;
    //
    //   // Check if the tree is dead then ensure health doesn't go below zero
    //   if (health <= 0)
    //   {
    //       health = 0; 
    //
    // Handle tree death, e.g., game over or other actions
    //   }
    //
    //   UpdateUIHealth();  // Update the UI based on the new health
    // }
    //}

}
