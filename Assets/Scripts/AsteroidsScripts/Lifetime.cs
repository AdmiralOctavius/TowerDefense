using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifetime = 2;
    void Start()
    {
        Invoke("KillObject", lifetime);
    }

    void KillObject()
    {
        Destroy(gameObject);
    }
}
