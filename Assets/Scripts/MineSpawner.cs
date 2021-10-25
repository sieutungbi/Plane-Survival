using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject minePrefab;

    public float minX = -9.5f, maxX = 9.5f;
    public float spawnInterval = 3.5f;
    public AudioClip sfxSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(StartSpawner), 1f);
    }

    void StartSpawner()
    {
        StartCoroutine(SpawnMines());
        Invoke(nameof(StartSpawner), spawnInterval);
    }


    IEnumerator SpawnMines()
    {
        int count = Random.Range(3, 8);
        
        Vector3 temp = transform.position;
        
        for (int i = 0; i < count; i++)
        {
            temp.x = Random.Range(minX, maxX);
            Instantiate(minePrefab, temp, Quaternion.identity);
            AudioManager.Instance.PlaySFX(sfxSpawn);
            yield return null;
        }
    }
}
