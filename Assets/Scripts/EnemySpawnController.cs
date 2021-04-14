using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{

    // General vars
    [SerializeField] private GameObject[] _enemyPrefab;
    [Range(1, 10)][SerializeField] private float _spawnRate = 1f;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(1/_spawnRate);
            float random = Random.Range(0.0f, 1.0f);
            if (random < GameManager.instance.difficulty * 0.1f) {
                Instantiate(_enemyPrefab[1]);
            } else 
            {
                Instantiate(_enemyPrefab[0]);
            }

        }
    }
}
