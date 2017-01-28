using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class LevelWave
{
	[XmlAttribute("Level")]
	public int Level;

	[XmlAttribute("EnemyType")]
	public int EnemyType;

	[XmlAttribute("EnemyCount")]
	public int EnemyCount;

	[XmlAttribute("SpawnTimeInSeconds")]
	public float SpawnTimeInSeconds;
}
