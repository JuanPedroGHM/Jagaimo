﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	private const string ENEMY_DEFAULT_NAME = "Enemy";

	[SerializeField]
	[System.Serializable]
	public struct Wave
	{
		public Enemy Enemy;
		public int EnemyCount;
		public float SpawnTimeInSeconds;
	}
	private List<Spawner> _spawners;

	private Enemy enemyPrefab;
	private int waveCounter;
	private int enemyCounter;
	private float timeBetweenSpawns;
	private float timeSinceLastSpawn;
	private List<LevelWave> levelWaves;
	// Use this for initialization
	void Start ()
	{
	    _spawners = FindObjectsOfType<Spawner>().ToList();
	        //load level wave config
		levelWaves = LevelWaveLoader.Load();
		
		//init first wave
		if(levelWaves.Count > 0)
		{
			timeBetweenSpawns = levelWaves[0].SpawnTimeInSeconds;
			enemyCounter = levelWaves[0].EnemyCount;
			waveCounter = 0;
			enemyPrefab = (Enemy)Resources.Load(ENEMY_DEFAULT_NAME + levelWaves[0].EnemyType, typeof(Enemy));
		}
	}
	

	// Update is called onced per frame
	void Update () {

	    if (timeSinceLastSpawn >= timeBetweenSpawns)
	    {
			//spawn enemies
	        foreach (var spawner in _spawners)
	        {
	            spawner.SpawnEnemy(enemyPrefab);
	            enemyCounter--;
	            if (enemyCounter <= 0) break;
	        }
	        timeSinceLastSpawn = 0;

			if(enemyCounter <= 0)
			{
				//load next wave
				waveCounter++;

				if(levelWaves.Count > waveCounter)
				{
					enemyPrefab = (Enemy)Resources.Load(ENEMY_DEFAULT_NAME + levelWaves[waveCounter].EnemyType, typeof(Enemy));
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