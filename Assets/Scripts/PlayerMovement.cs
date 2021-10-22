using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float rotaionSpeed = 200f;

    private float horizontal;
    private float vertical;
    public GameObject explosion;

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        transform.Translate(Vector2.up * speed * Time.deltaTime,Space.Self);
        transform.Rotate(Vector3.forward * -horizontal * rotaionSpeed * Time.deltaTime);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Enemy") || target.CompareTag("Mine"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Invoke("RestartGame", 2f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
