using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // General vars
    float h, v;
    [SerializeField] private float _speed;
    Vector3 moveDirection;
    [SerializeField] private Transform _aim;
    [SerializeField] private Camera camera;
    private Vector2 _facingDirection;
    public Transform bullet;
    private bool _gunLoaded = true;
    [SerializeField] private float fireRate = 1;

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
            Instantiate(bullet, transform.position, targetRotation);
            StartCoroutine(ReloadGun());
        }

    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        _gunLoaded = true;
    }
}
