using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Put this script on the player.
 * The script decreases the player's health by 1 unit when it collides with an enemy.
 * Script also flashes the player red 3x;
 */

public class HasHealth : MonoBehaviour
{
    public AudioClip hurtAudio;

    public int currentHealth = 3;

    public static HasHealth instance;
    [HideInInspector] public bool lostLife = false;

    private SpriteRenderer sr;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lostLife)
        {
            
            //lostLife = false;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            // if player gets hit
            if (collision.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("Spider"))
            {
                //decrease health by 1
                Destroy(collision.gameObject);
                StartCoroutine(HealthFlash());
                currentHealth--;
                lostLife = true;

                // Play sound effect at the location of the main camera
                AudioSource.PlayClipAtPoint(hurtAudio, Camera.main.transform.position);
            }
        }
    }

    IEnumerator HealthFlash()
    {
        if (sr != null && this.gameObject.CompareTag("Spider"))
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.white;
        }
        yield return null;
    }
}
