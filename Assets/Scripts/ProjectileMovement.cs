using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script moves the projectile in a straight line rightward.
 * Change the speed to negative for the projectile to move leftward
 */

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }
}
