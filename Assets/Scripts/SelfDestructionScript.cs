using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructionScript : MonoBehaviour
{
    public float delay = 1f;

    void Start()
    {
        StartCoroutine(BeginSelfDestruction());
    }

    private IEnumerator BeginSelfDestruction()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
