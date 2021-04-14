using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerController : MonoBehaviour
{
    // General vars
    [SerializeField] private int _spawnItemTime = 5;
    [SerializeField] private int _spawnRadius = 5;
    [SerializeField] private int _spawnPowerUpTime = 5;
    [SerializeField] private GameObject _checkpointPrefab;
    [SerializeField] private GameObject[] _powerUpPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItemRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnItemRoutine()
    {
        while (true) 
        {
            yield return new WaitForSeconds(_spawnItemTime);
            Vector2 randomPosition = Random.insideUnitCircle * _spawnRadius;
            Instantiate(_checkpointPrefab, randomPosition, Quaternion.identity);
        }

    }

    IEnumerator SpawnPowerUpRoutine() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(_spawnPowerUpTime);
            Vector2 randomPosition = Random.insideUnitCircle * _spawnRadius;
            int randomPowerUp = Random.Range(0, _powerUpPrefabs.Length);
            Instantiate(_powerUpPrefabs[randomPowerUp], randomPosition, Quaternion.identity);

        }
    }
}
