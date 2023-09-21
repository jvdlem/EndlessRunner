using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Vector3 speed = new Vector3(0, 0, 0);
    public bool isOnGround = false;
    public float scaleSize = 1;
    public bool dubbleJump = false;
    public bool canPlay = false;
    public ParticleSystem slideParticle = null;
    public Vector3 offSetParticle = Vector3.zero;
    public SpawnManager spawner = null;
    void Start()
    {

    }

    // Update is called once per frames
    private void Update()
    {


        if (canPlay)
        {
            var emission = slideParticle.emission;
            slideParticle.gameObject.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z) + offSetParticle;
            slideParticle.gameObject.transform.localScale = new Vector3(this.transform.localScale.y, slideParticle.gameObject.transform.localScale.y, slideParticle.gameObject.transform.localScale.z);
            if (isOnGround)
            {
                var main = slideParticle.main;
                main.startSpeed = spawner.movementSpeed*spawner.movementSpeed-100;
                emission.rateOverTime = spawner.movementSpeed * spawner.movementSpeed-100;  // Adjust the emission rate as needed when the player is on the ground
            }
            else
            {
                emission.rateOverTime = 0f; // Set emission rate to 0 when the player is not on the ground
            }

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
            else if (Input.GetKeyDown("space") && !isOnGround && !dubbleJump)
            {
                rb.AddForce(Vector3.down * speed.y * rb.mass * 2, ForceMode.Impulse);
            }
            if (Input.GetKey("s"))
            {
                scaleSize += 0.1f;
                transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(1, 0.5f, scaleSize), transform.localScale.z);
            }
            else
            {
                if (scaleSize > 0)
                {
                    scaleSize -= 1f;
                    transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(1, 0.5f, scaleSize), transform.localScale.z);
                }
            }
            if (Input.GetKey("e"))
            {
                float rotationIncrement = 1f;
                Quaternion currentRotation = this.transform.rotation;
                Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, rotationIncrement);
                this.transform.rotation = newRotation;
            }
            if (Input.GetKey("q"))
            {
                float rotationIncrement = -1f;
                Quaternion currentRotation = this.transform.rotation;
                Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, rotationIncrement);
                this.transform.rotation = newRotation;
            }

            // Calculate the force vector
            Vector3 force = new Vector3(horizontalInput * speed.x * Time.deltaTime, jumpInput ? speed.y * rb.mass : 0, verticalInput * speed.z * Time.deltaTime);

            // Apply the force
            rb.AddForce(force, jumpInput ? ForceMode.Impulse : ForceMode.VelocityChange);
        }
    }


}
