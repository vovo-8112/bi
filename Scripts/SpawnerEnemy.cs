using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnTime = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyWave());
    }

    private void spawnerEnemy()
    {
        GameObject a = Instantiate(enemyPrefab)as GameObject;
        a.transform.position = new Vector2(Random.Range(-3.6f,-5f), Random.Range(-1.42f, 1.42f));
    }
    IEnumerator enemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnerEnemy();

        }
    }
}
