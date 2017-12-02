using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

    public GameObject CarParent;
    public float minSpawnTime;
    public float maxSpawnTime;
    public float maxCarsPerSpawner = 2;
    float spawnTime;
    float spawnTimer;

    List<GameObject> spawnedCars = new List<GameObject>();

	// Use this for initialization
	void Start () {
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }


    private void Update()
    {
        if(spawnedCars.Count < maxCarsPerSpawner)
            spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnTime)
        {
            spawnTimer = 0f;
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            GameObject go = GameObject.Instantiate(Resources.Load("Car"), this.gameObject.transform.position, transform.rotation) as GameObject;
            go.transform.parent = CarParent.transform;
            spawnedCars.Add(go);

        }
    }
}
