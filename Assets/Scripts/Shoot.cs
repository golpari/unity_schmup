using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Add this script to any item that should shoot a projectile
 */

public class Shoot : MonoBehaviour
{
    public AudioClip shootAudio;

    public GameObject desiredProjectile;
    public bool shootOnPress = true; //default value is true, can add functionality for automatically shot enemy projectiles if setting is 'false' though

    // Start is called before the first frame update
    void Start()
    {
        if (desiredProjectile == null)
        {
            Console.Error.WriteLine("Projectile gameObject of 'shoot' script not specified in inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shootOnPress)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Play sound effect at the location of the main camera
                AudioSource.PlayClipAtPoint(shootAudio, Camera.main.transform.position, 5);
                Instantiate(desiredProjectile, this.transform.position + Vector3.right, Quaternion.identity);
            }
        }
    }
}
