using UnityEngine;

public class OceanScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.CompareTag("Player"))
        {
            GameManager.Instance.EndGame();
        }
    }
}
