using UnityEngine;

public class Spawner :MonoBehaviour
{
    public void SpawnEnemy(GameObject Enemy)
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }


}