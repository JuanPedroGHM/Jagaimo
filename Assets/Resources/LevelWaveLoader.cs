using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWaveLoader
{

	public const string path = "LevelWaves";

	public static List<LevelWave> Load()
	{
		LevelWaveContainer levelWaveContainer = LevelWaveContainer.Load(path);
		return levelWaveContainer.levelWaves;
	}
}
