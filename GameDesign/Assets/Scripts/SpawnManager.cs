using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> preFabs = new List<GameObject> ();
    public List<GameObject> obstacles = new List<GameObject>();
    public List<ObstacleMovement> scripts = new List<ObstacleMovement>();
    public GameManager manager;
    public float spawnTimer = 0;
    public float spawnSpeed = 0;
    public float spawnThreshhold = 0;
    public float movementSpeed = 0;
    public float movementSpeedIncrease = 0;
    public float moventSpeedCap = 100;

    private void Start()
    {
        spawnPrefabs();
    }
    private void Update()
    {
        if (manager.obstaclesSpawn)
        {
            if (movementSpeed < moventSpeedCap)
            {
                movementSpeed += movementSpeedIncrease;
            }
            spawnTimer += spawnSpeed;
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
            GameObject obj =  Instantiate(preFabs[i],this.transform.position,this.transform.rotation);
            obstacles.Add(obj);
            obj.SetActive(false);
            scripts.Add(obj.GetComponent<ObstacleMovement>());
        }
    
    }
}
