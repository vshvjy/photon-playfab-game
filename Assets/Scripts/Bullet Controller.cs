using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControlle : MonoBehaviour
{
    Rigidbody rigidBody;

    public float fireRate = 0.75f;

    public GameObject bulletPrefab;
    public Transform bulletPosition;
    float nextFire;


    public float bulletSpeed = 15f;

    public void InitializeBullet(Vector3 originalDirection)
    {
        transform.forward = originalDirection;
        rigidBody.velocity = transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);

            bullet.GetComponent<BulletControlle>()?.InitializeBullet(transform.rotation * Vector3.forward);
        }

    }

    void FixedUpdate()
    {
        Move();

        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }

        void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Move()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
