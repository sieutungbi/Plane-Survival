using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject rocket, plane;

    public bool spawnRocket, spawnPlane;

    public float spawnTime = 3f;
    public AudioClip sfxSpawn;

    private ObjectPool _objectPool;
    // Start is called before the first frame update
    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
        StartSpawning();
    }

    void SpawnEnemy()
    {
        GameObject go = null;
        if (spawnRocket)
        {
            //go = Instantiate(rocket, transform.position, Quaternion.identity);
            go = _objectPool.GetObject(rocket);
            go.transform.position = this.transform.position;
        }

        if (spawnPlane)
        {
            //go = Instantiate(plane, transform.position, Quaternion.identity);
            go = _objectPool.GetObject(plane);
            go.transform.position = this.transform.position;
        }

        go.GetComponent<Enemy>().enemySpawner = this;
        AudioManager.Instance.PlaySFX(sfxSpawn);
    }

    public void StartSpawning()
    {
        Invoke("SpawnEnemy", spawnTime);
    }
}
