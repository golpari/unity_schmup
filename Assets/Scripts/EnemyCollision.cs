using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Place this script on the web / on whatever item will be getting destroyed
 * when the collision is triggered. 
 * 
 * Script will destory the projectile and the enemy gameObjects
 * 
 * NOTE: a good game should also destroy the projectiles and enemies when they exit the viewport but I am lazy so havent done it yet
 */

[RequireComponent(typeof(Collider2D))]
public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            // on collision of enemy and a web projectile
            if (collision.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("Web"))
            {
                //count the bug u killed for win counter
                GameOverCondition.instance.bugsKilled++;
                // destroy the ebemy AND THEN the web afterward
                // this script will be on the web, so it needs to destroy the web last
                Destroy(collision.gameObject, 0.3f);
                Destroy(this.gameObject, 0.3f);
            } 
        }
    }
}
