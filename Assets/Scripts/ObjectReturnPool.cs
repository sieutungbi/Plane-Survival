using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReturnPool : MonoBehaviour
{
    private ObjectPool _objectPool;
    // Start is called before the first frame update
    void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    private void OnDisable()
    {
        if ( _objectPool != null)
        {
            _objectPool.ReturnGameObject(this.gameObject);
        }
    }
}
