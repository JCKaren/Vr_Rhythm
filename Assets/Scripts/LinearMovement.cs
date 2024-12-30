using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private static float globalSpeed = 2f; // Shared speed value for all cubes

    private float speed; // Instance-specific speed

    void Start()
    {
        // Assign the current global speed to this instance
        speed = globalSpeed;
    }

    void Update()
    {
        transform.Translate(0, 0, -1 * (speed * Time.deltaTime));
    }

    public static void UpdateGlobalSpeed(float newSpeed)
    {
        // Update the global speed for all cubes
        globalSpeed = newSpeed;
    }
}
