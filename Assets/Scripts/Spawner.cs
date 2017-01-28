using UnityEngine;

public class Spawner :MonoBehaviour
{
    public void SpawnEnemy(GameObject Enemy)
    {
		if (Enemy != null)
		{
			Instantiate(Enemy, transform.position, transform.rotation);
			return;
		}
		else
		{
			Debug.LogError("SpawnEnemy: No reference to enemy... =(");
		}
	}


}