using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField]
    float startDelay = 3f;

    [SerializeField]
    float spawnTime = 3f;
    // Use this for initialization
    void Start ()
    {
       InvokeRepeating("Spawn", startDelay, spawnTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
