using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsters;
    private readonly int[] SPAWNER_POS_X = {-70, 70};

    private const string PLAYER_TAG = "Player";

    void Start()
    {
        StartCoroutine(this.spawnEnemy());
    }

    
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy() 
    {
        while(true) {
            yield return new WaitForSeconds(Random.Range(1, 5));

            int currentEnemy = Random.Range(0, 3);
            int currentSpawner = Random.Range(0, 2);

            GameObject spawnedMonster = Instantiate(monsters[currentEnemy]);

            spawnedMonster.transform.position = new Vector3(this.SPAWNER_POS_X[currentSpawner], spawnedMonster.transform.position.y, spawnedMonster.transform.position.z);
        }
    }
}
