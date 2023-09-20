using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<ObstacleMovement> preFabs = new List<ObstacleMovement>();
    public float spawnTimer = 0;
    public float spawnSpeed = 0;
    public float spawnThreshhold = 0;
    public float movementSpeed = 0;
    public float movementSpeedIncrease = 0;


    private void Update()
    {
        movementSpeed += movementSpeedIncrease;
        spawnTimer += spawnSpeed;
        if (spawnTimer > spawnThreshhold)
        {
            spawnTimer = 0;
            spawnObstacle(preFabs[(int)Random.Range(0, preFabs.Count)]);
        }
    }

    private void spawnObstacle(ObstacleMovement objects)
    {
        objects.enabled = true;
        objects.moveSpeed = movementSpeed;
        objects.transform.position = objects.spawnPositions[Random.Range(0, objects.spawnPositions.Count)]; 
    }
}
