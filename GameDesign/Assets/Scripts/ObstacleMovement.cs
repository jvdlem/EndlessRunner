using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed;

    public Vector3 endPosition;
    public Vector3 startposition;
    public List<Vector3> spawnPositions;
    public bool canSpawn = false;

    public Rigidbody rigidbody;

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(0, 0, -moveSpeed * Time.deltaTime, ForceMode.VelocityChange);

        if (transform.position.z <= endPosition.z)
        {
            canSpawn = true;
            this.gameObject.SetActive(false);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
