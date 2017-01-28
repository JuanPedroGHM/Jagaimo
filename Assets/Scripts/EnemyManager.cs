using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    [SerializeField]
    public List<Wave> Waves;


    public List<Spawner> Spawners;
    public float timeBetweenSpawns;

    private float timeSinceLastSpawn;
    // Use this for initialization
	void Start () {
		
	}


    [System.Serializable]
    public struct Wave
    {
        public Enemy Enemy;
        public int EnemyCount;
        public float SpawnTimeInSeconds;
    }

    // Update is called once per frame
	void Update () {

	    if (timeSinceLastSpawn >= timeBetweenSpawns)
	    {
	        foreach (var spawner in Spawners)
	        {
	            spawner.SpawnEnemy(EnemyPrefab);
	        }
	        timeSinceLastSpawn = 0;

	    }
	    timeSinceLastSpawn += Time.deltaTime;
	}
}