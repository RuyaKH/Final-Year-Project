﻿using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    //trigger to check for 
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        if (collider.tag == "bullet")
        {
            cube.SetActive(false);
        }
    }
}
