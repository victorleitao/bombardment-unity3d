using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotationScript : MonoBehaviour
{
    public float rotationSpeed = 1;
    void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
}
