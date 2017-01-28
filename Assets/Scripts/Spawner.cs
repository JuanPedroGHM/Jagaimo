using UnityEngine;

public class Spawner :MonoBehaviour
{
    private Player Player;
    public void Start()
    {
        Player = FindObjectOfType<Player>();
    }

    public void SpawnEnemy(Enemy Enemy)
    {
		if (Enemy != null)
		{
		    var enemy = Instantiate(Enemy, transform.position, transform.rotation);
		    enemy.Player = Player;
		}
		else
		{
			Debug.LogError("SpawnEnemy: No reference to enemy... =(");
		}
	}


}