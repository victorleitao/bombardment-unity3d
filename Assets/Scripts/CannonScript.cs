using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public List<GameObject> bombPrefabs;
    public Vector2 timeInterval = new Vector2(1, 1);
    private float timeIncrementRatio = 1;
    public float initialCooldown = 0;
    public GameObject spawnPoint;
    public GameObject target;
    public float rangeInDegrees;
    public float arcDegrees;
    public Vector2 force;

    void FixedUpdate()
    {
        // Ignore if game is over
        if (GameManager.Instance.isGameOver) return;

        // Update initialCooldown
        initialCooldown -= Time.fixedDeltaTime;
        if (initialCooldown < 0)
        {
            initialCooldown = Mathf.Clamp(Random.Range(timeInterval.x, timeInterval.y)
            * timeIncrementRatio, 0.5f, timeInterval.y);

            // Fire
            Fire();

            // Sudden death increase (if active)
            timeIncrementRatio -= GameManager.Instance.suddenDeathRatio;
        }
    }

    private void Fire()
    {
        // Get prefab
        GameObject bombPrefab = bombPrefabs[Random.Range(0, bombPrefabs.Count)];

        // Instantiate bomb
        GameObject bomb = Instantiate(bombPrefab, spawnPoint.transform.position, bombPrefab.transform.rotation);

        // Apply force
        Rigidbody bombRigidbody = bomb.GetComponent<Rigidbody>();
        Vector3 impulseVector = target.transform.position - spawnPoint.transform.position;
        impulseVector.Scale(new(1, 0, 1));
        impulseVector.Normalize();
        impulseVector += new Vector3(0, arcDegrees / 45f, 0);
        impulseVector.Normalize();
        impulseVector = Quaternion.AngleAxis(rangeInDegrees * Random.Range(-1f, 1f), Vector3.up) * impulseVector;
        impulseVector *= Random.Range(force.x, force.y);
        bombRigidbody.AddForce(impulseVector, ForceMode.Impulse);
    }
}
