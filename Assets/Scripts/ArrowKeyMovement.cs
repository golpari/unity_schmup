using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArrowKeyMovement : MonoBehaviour
{
    public float movement_speed = 4;
    private Rigidbody2D rb;
    private Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        // Store a reference to the RIgidbody component on this game object
        // Prevents us from calling GetComponent() every frame --> saves performance
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentInput = GetInput();
        rb.velocity = currentInput * movement_speed;
    }

    Vector2 GetInput()
    {
        // Input.GetAxis uses InputManager, which standardizes controls so they work on keyboard or controller

        // curr val of right-left keys
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        // curr val of up-down keys
        float vertical_input = Input.GetAxisRaw("Vertical");

        return new Vector2(horizontal_input, vertical_input);
    }
}
