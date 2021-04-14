using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // General vars
    [SerializeField] private int _health = 3;
    float h, v;
    [SerializeField] private float _speed;
    Vector3 moveDirection;
    private Vector2 _facingDirection;
    private bool _gunLoaded = true;
    [SerializeField] private float fireRate = 1;
    [SerializeField] private bool _powerShootEnabled;
    [SerializeField] private bool _invulnerabilityEnabled = false;
    [SerializeField] private int _invulnerabilityTime = 3;

    // References
    [SerializeField] private Camera camera;
    [SerializeField] private Transform _aim;
    public Transform bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        moveDirection.x = h;
        moveDirection.y = v;

        this.transform.position += moveDirection * Time.deltaTime * _speed;  

        // Aim movement
        _facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _aim.position = transform.position + (Vector3)_facingDirection.normalized;

        // Detect user click to shoot
        if (Input.GetMouseButton(0) && _gunLoaded) 
        {
            _gunLoaded = false;
            float angle = Mathf.Atan2(_facingDirection.y, _facingDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Transform newBullet  = Instantiate(bullet, transform.position, targetRotation);
            if (_powerShootEnabled)
            {
                newBullet.GetComponent<BulletController>().powerShoot = true;
                _powerShootEnabled = false;
            }
            StartCoroutine(ReloadGun());
        }
    }

    // Coroutine to reload the gun
    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        _gunLoaded = true;
    }

    // Decrease player health
    public void TakeDamage()
    {
        _health--;

        // Check player health
        if (_health <= 0)
        {
            //TODO: Game over
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // ENemy touch player
        if (other.CompareTag("Enemy"))
        {
            if (!_invulnerabilityEnabled) 
            {
                TakeDamage();
            }
            
        }    

        // Coller Power Up
        if (other.CompareTag("PowerUp")) 
        {
            switch (other.GetComponent<PowerUp>().powerUpType)
            {
                case PowerUp.PowerUpType.FireRateIncrease:
                    fireRate++;
                    break;
                case PowerUp.PowerUpType.PowerShot:
                    _powerShootEnabled = true;
                    break;
                case PowerUp.PowerUpType.Invulnerability:
                    StartCoroutine(ActiveInvulnerability());
                    break;
            }
            Destroy(other.gameObject, 0.1f);
        } 
    }

    IEnumerator ActiveInvulnerability()
    {
        _invulnerabilityEnabled = true;
        yield return new WaitForSeconds(_invulnerabilityTime);
        _invulnerabilityEnabled = false;
    }
}
