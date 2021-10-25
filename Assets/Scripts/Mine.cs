using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            gameObject.SetActive(false);            
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Enemy") || target.CompareTag("Bullet"))
        {
            target.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
