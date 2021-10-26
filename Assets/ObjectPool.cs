using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();

    public GameObject GetObject(GameObject gameObject)
    {
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            if (objectList.Count == 0)
            {
                return CreateNewObject(gameObject);
            }
            else
            {
                GameObject _gameObject = objectList.Dequeue();
                _gameObject.SetActive(true);
                return _gameObject;
            }
        }
        else
        {
            return CreateNewObject(gameObject);
        }
    }

    private GameObject CreateNewObject(GameObject gameObject)
    {
        GameObject newGO = Instantiate(gameObject);
        newGO.name = gameObject.name;
        return newGO;
    }

    public void ReturnGameObject(GameObject gameObject)
    {
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(gameObject);
        }
        else
        {
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(gameObject);
            objectPool.Add(gameObject.gameObject.name, newObjectQueue);
        }
        gameObject.SetActive(false);
    } 
}
