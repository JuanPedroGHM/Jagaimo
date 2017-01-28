using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("LevelCollection")]
public class LevelWaveContainer
{
	[XmlArray("LevelWaves")]
	[XmlArrayItem("LevelWave")]
	public List<LevelWave> levelWaves = new List<LevelWave>();

	public static LevelWaveContainer Load(string path)
	{
		TextAsset xml = Resources.Load<TextAsset>(path);

		if (xml == null)
		{
			throw new System.Exception("Die fucking Level Config konnte nicht geladen werden. Der File-Pfad ist scheisse");
		}

		XmlSerializer serializer = new XmlSerializer(typeof(LevelWaveContainer));
		StringReader reader = new StringReader(xml.text);
		LevelWaveContainer levelWaves = serializer.Deserialize(reader) as LevelWaveContainer;

		reader.Close();

		return levelWaves;
	}

}
