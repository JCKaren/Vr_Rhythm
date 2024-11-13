using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    //private Vector3 spawnRotation;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, -1*(speed * Time.deltaTime));

    }

}
