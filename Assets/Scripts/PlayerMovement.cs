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
    public AudioClip sfxExplosion;
    private FixedJoystick _joystick;

    private void Awake()
    {
        _joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        
#if UNITY_EDITOR
        horizontal = Input.GetAxisRaw("Horizontal");
#else
        horizontal = _joystick.Horizontal;
#endif
        
        transform.Translate(Vector2.up * speed * Time.deltaTime,Space.Self);
        transform.Rotate(Vector3.forward * -horizontal * rotaionSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Enemy") || target.CompareTag("Mine"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySFX(sfxExplosion);
            GameManager.Instance.RestartGame(2f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
