using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerController : MonoBehaviour
{
    // General vars
    [SerializeField] private int _spawnTime = 5;
    [SerializeField] private int _spawnRadius = 5;
    [SerializeField] private GameObject _checkpointPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        while (true) 
        {
            yield return new WaitForSeconds(_spawnTime);
            Vector2 randomPosition = Random.insideUnitCircle * _spawnRadius;
            Instantiate(_checkpointPrefab, randomPosition, Quaternion.identity);
        }

    }
}
