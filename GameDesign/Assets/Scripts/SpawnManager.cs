using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> preFabs = new List<GameObject>();
    public List<GameObject> obstacles = new List<GameObject>();
    public List<ObstacleMovement> scripts = new List<ObstacleMovement>();
    public GameManager manager;
    public float spawnTimer = 0;
    public float spawnSpeed = 0;
    public float spawnThreshhold = 0;
    public float movementSpeed = 0;
    public float movementSpeedIncrease = 0;
    public float moventSpeedCap = 100;
    public float spawnSpeedcap = 0.2f;
    public float spawnSpeedIncrement = 0.001f;

    public List<GameObject> walls = new List<GameObject>();

    private void Start()
    {
        spawnPrefabs();
    }
    private void FixedUpdate()
    {
        if (manager.obstaclesSpawn)
        {
            if (movementSpeed < moventSpeedCap)
            {
                movementSpeed += movementSpeedIncrease;
            }
            spawnTimer += spawnSpeed;
            if (spawnSpeed < spawnSpeedcap)
            {
                spawnSpeed += spawnSpeedIncrement / 1000;
            }
            if (spawnTimer > spawnThreshhold)
            {
                spawnTimer = 0;
                spawnObstacle((int)Random.Range(0, obstacles.Count));
            }

        }

    }

    private void spawnObstacle(int index)
    {
        if (scripts[index].canSpawn)
        {
            ObstacleMovement currentObjScript = scripts[index];
            GameObject currentObj = obstacles[index];
            currentObjScript.canSpawn = false;
            currentObj.transform.position = currentObjScript.spawnPositions[Random.Range(0, currentObjScript.spawnPositions.Count)];
            currentObj.SetActive(true);
            currentObjScript.moveSpeed = movementSpeed;
        }
    }

    private void spawnPrefabs()
    {
        for (int i = 0; i < preFabs.Count; i++)
        {
            GameObject obj = Instantiate(preFabs[i], this.transform.position, this.transform.rotation);
            obstacles.Add(obj);
            obj.SetActive(false);
            scripts.Add(obj.GetComponent<ObstacleMovement>());
        }

    }

    public void ResetGame()
    {
        spawnTimer = 0;
        spawnSpeed = 0.1f;
        this.movementSpeed = 10;
        for (int i = 0; i < scripts.Count; i++)
        {
            ObstacleMovement currentObjScript = scripts[i];
            GameObject currentObj = obstacles[i];
            currentObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
            currentObjScript.canSpawn = true;
            currentObjScript.moveSpeed = movementSpeed;
            currentObj.transform.position = currentObjScript.spawnPositions[Random.Range(0, currentObjScript.spawnPositions.Count)];
            currentObj.SetActive(false);

        }
    }
}
