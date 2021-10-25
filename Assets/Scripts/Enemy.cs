using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;

    private Transform playerTarget;
    private Rigidbody2D mybody;

    public EnemySpawner enemySpawner;
    public GameObject explosion;
    public AudioClip sfxExplosion;
    
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        playerTarget = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerTarget == null)
            return;

        Vector2 point2Target = (Vector2)transform.position - (Vector2)playerTarget.position;
        point2Target.Normalize();

        float value = Vector3.Cross(point2Target, transform.up).z;
        mybody.velocity = transform.up * speed;
        mybody.angularVelocity = rotationSpeed * value;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Mine"))
        {
            enemySpawner.StartSpawning();
            Instantiate(explosion, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySFX(sfxExplosion);
        }
    }
}
