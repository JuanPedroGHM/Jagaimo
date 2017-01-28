using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    [SerializeField]
	[System.Serializable]
	public struct Wave
	{
		public Enemy Enemy;
		public int EnemyCount;
		public float SpawnTimeInSeconds;
	}
	public List<Spawner> Spawners;

	private int waveCounter;
	private int enemyCounter;
	private float timeBetweenSpawns;
	private float timeSinceLastSpawn;
	private List<LevelWave> levelWaves;
	// Use this for initialization
	void Start ()
	{
		//load level wave config
		levelWaves = LevelWaveLoader.Load();
		
		//init first wave
		if(levelWaves.Count > 0)
		{
			timeBetweenSpawns = levelWaves[0].SpawnTimeInSeconds;
			enemyCounter = levelWaves[0].EnemyCount;
			waveCounter = 0;
			//TODO: load enemy type
		}
	}
	

	// Update is called once per frame
	void Update () {

	    if (timeSinceLastSpawn >= timeBetweenSpawns)
	    {
			//spawn enemies
	        foreach (var spawner in Spawners)
	        {
	            spawner.SpawnEnemy(EnemyPrefab);
	        }
	        timeSinceLastSpawn = 0;
			enemyCounter--;
			
			if(enemyCounter <= 0)
			{
				//load next wave
				waveCounter++;

				if(levelWaves.Count > waveCounter)
				{
					//TODO: load enemy type
					timeBetweenSpawns = levelWaves[waveCounter].SpawnTimeInSeconds;
					enemyCounter = levelWaves[waveCounter].EnemyCount;
				}
				else
				{
					//if there is no wave left continue with last wave
				}

			}
		}
	    timeSinceLastSpawn += Time.deltaTime;
	}
}