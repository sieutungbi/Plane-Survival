using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    public AudioClip sfxExplosion;
    
    // When bullet goes out of the screen
    void OnBecameInvisible() {  
         //Destroy the bullet
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Enemy") || target.CompareTag("Mine"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySFX(sfxExplosion);
            target.gameObject.SetActive(false);
            gameObject.SetActive(false);
            GameManager.Instance._score += 10;
        }
    }
}
