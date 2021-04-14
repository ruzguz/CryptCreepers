using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // General vars
    [SerializeField] private float _speed = 5;
    private int _lifeTime = 5;
    [SerializeField] private int _health = 3;
    public bool powerShoot;
 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        // Bullet collide with enemy
        if (other.CompareTag("Enemy")) 
        {
            other.GetComponent<EnemyController>().TakeDamage();

            if (!powerShoot) 
            {
                Destroy(gameObject);
            }

            _health--;

            if (_health <= 0) 
            {
                Destroy(gameObject);
            }

        }
    }
}
