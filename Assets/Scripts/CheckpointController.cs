using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    // General vars 
    [SerializeField] private int _timeToAdd = 10;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.time += _timeToAdd;
            Destroy(gameObject, 0.1f);
        }
    }
}
