using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        Invoke("DeActivateExplosion", 2f);
    }

    void DeActivateExplosion()
    {
        gameObject.SetActive(false);
    }
}
