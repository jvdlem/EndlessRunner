using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed;

    public Vector3 endPosition;
    public Vector3 startposition;
    public List<Vector3> spawnPositions;

    public Rigidbody rigidbody;


    // Start is called before the first frame update
    void Awake()
    {
        Vector3 tempPos = startposition + new Vector3(Random.Range(0, 1), Random.Range(0, 1),0);

    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(0, 0, -moveSpeed * Time.deltaTime, ForceMode.VelocityChange);

        if (transform.position.z <= endPosition.z)
        {
            this.enabled = false;
        }
    }
}
