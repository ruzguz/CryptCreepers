using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;

    // General vars
    public int difficulty = 1;
    public int time = 30;
    
    private void Awake() {
        if (instance == null) 
        {
            instance = this;
        } else 
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
        StartCoroutine(TimeCountdown());
    }

    IEnumerator TimeCountdown() 
    {
        while (time > 0) 
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }
}
