using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.5f;
    public float rotaionSpeed = 350f;

    private float horizontal;
    public GameObject explosion;
    public AudioClip sfxExplosion;
    private FixedJoystick _joystick;

    private Vector3 screenBounds;
    private float objectWidth, objectHeight;
    
    public Camera MainCamera;
    
    // Use this for initialization
    void Start () {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    private void Awake()
    {
#if !UNITY_EDITOR
        _joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
#endif
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
#if UNITY_EDITOR
        horizontal = Input.GetAxisRaw("Horizontal");
#else
        horizontal = _joystick.Horizontal;
#endif
        
        transform.Translate(Vector2.up * speed * Time.deltaTime,Space.Self);
        transform.Rotate(Vector3.forward * -horizontal * rotaionSpeed * Time.deltaTime);
    }

    void LateUpdate(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
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
