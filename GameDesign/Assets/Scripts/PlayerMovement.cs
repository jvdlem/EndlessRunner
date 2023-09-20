using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Vector3 speed = new Vector3(0,0,0);
    public bool isOnGround = false;
    void Start()
    {

    }

    // Update is called once per frames
    private void Update()
    {
        float horizontalInput = 0;
        float verticalInput = 0;
        bool jumpInput = false;

        // Get input values
        if (Input.GetKey("d"))
        {
            horizontalInput += 1;
        }
        if (Input.GetKey("a"))
        {
            horizontalInput -= 1;
        }
        if (Input.GetKey("w"))
        {
            verticalInput += 1;
        }
        if (Input.GetKeyDown("space") && isOnGround)
        {
            jumpInput = true;
            isOnGround = false;
        }

        // Calculate the force vector
        Vector3 force = new Vector3(horizontalInput * speed.x * Time.deltaTime, jumpInput ? speed.y : 0, verticalInput * speed.z * Time.deltaTime);

        // Apply the force
        rb.AddForce(force, jumpInput ? ForceMode.Impulse : ForceMode.VelocityChange);
    }
}
