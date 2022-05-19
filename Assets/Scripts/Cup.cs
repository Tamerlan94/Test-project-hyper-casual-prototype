using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponentInChildren<Rigidbody>();
    }
}
