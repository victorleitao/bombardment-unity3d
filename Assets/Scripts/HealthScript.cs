using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector]
    public int health;
    void Start()
    {
        health = maxHealth;
    }
}
