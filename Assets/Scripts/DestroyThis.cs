using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    [SerializeField] float destroyDelay = 10f;
    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
}
