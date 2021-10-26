using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform bulletSpawn;
    private float timeBetweenShots = 0.1f; 
    private float timestamp;
    private float bulletSpeed = 30f;
    public AudioClip sfxFire;
    
    private ObjectPool _objectPool;
    // Start is called before the first frame update
    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }
    
    private void OnEnable()
    {
        GameManager.Instance.fireEnable = true;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FirePressed();
        }
    }
#endif
    public void FirePressed () 
    {
        if (Time.time >= timestamp && GameManager.Instance.fireEnable) {
            // Shoot bullet
            AudioManager.Instance.PlaySFX(sfxFire);
            //GameObject bullet = Instantiate(playerBullet, bulletSpawn.position, Quaternion.identity);
            GameObject bullet = _objectPool.GetObject(playerBullet);
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = Quaternion.identity;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bulletSpawn.up * bulletSpeed, ForceMode2D.Impulse);
            timestamp = Time.time + timeBetweenShots;
        }
    }
}
