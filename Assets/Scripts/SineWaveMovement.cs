using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script moves a gameobject in a sine wave pattern to the left.
 * Place this script on any gameobject that you want to move in this way.
 */

[RequireComponent(typeof(Rigidbody2D))]
public class SineWaveMovement : MonoBehaviour
{
    public float frequency = 1.0f; // Speed of sine movement
    public float magnitude = 1.0f; // Size of sine movement
    public float moveSpeed = 1.0f; // Speed of movement to the left

    private Rigidbody2D rb;
    private Vector3 startVelocity;
    private float sineWaveOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Initialize velocity to move left
        startVelocity = new Vector3(-moveSpeed, 0f, 0f);
        rb.velocity = startVelocity;

        sineWaveOffset = 0f;
    }

    void FixedUpdate()
    {
        sineWaveOffset = Mathf.Sin(Time.time * frequency) * magnitude;

        // Apply the sine wave as a vertical offset
        rb.velocity = new Vector3(startVelocity.x, sineWaveOffset, startVelocity.z);
    }
}
