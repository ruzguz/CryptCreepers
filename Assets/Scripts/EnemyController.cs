using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // General vars
    [SerializeField] private int health = 1;
    [SerializeField] private float _speed = 1;
    private Transform _player;
    

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Make enemy follow the player
        Vector2 direction = _player.position - transform.position;
        transform.position += (Vector3)direction.normalized * Time.deltaTime * _speed;
        
    }

    // Decrease enemy health
    public void TakeDamage()
    {
        health--;
    }
}
