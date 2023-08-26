using System.Collections;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float explosionDelay = 5f;
    public GameObject explosionPrefab;
    public GameObject woodBreakingPrefab;
    public float blastRadius = 5;
    public int blastDamage = 10;

    private void Start()
    {
        StartCoroutine(ExplosionCoroutine());
    }

    private IEnumerator ExplosionCoroutine()
    {
        // Wait until bomb explodes
        yield return new WaitForSeconds(explosionDelay);

        // Explode
        Explode();
    }

    private void Explode()
    {
        // Check if game is active
        if (GameManager.Instance.isGameOver) return;

        // Create Explosion
        Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);

        // Destroy platforms
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider collider in colliders)
        {
            GameObject hitObject = collider.gameObject;
            if (hitObject.CompareTag("Platform"))
            {
                HealthScript healthScript = hitObject.GetComponent<HealthScript>();
                if (healthScript != null)
                {
                    float distance = (hitObject.transform.position - transform.position).magnitude;
                    float distanceRate = Mathf.Clamp(distance / blastRadius, 0, 1);
                    float damageRate = 1f - Mathf.Pow(distanceRate, 3);
                    int damage = (int)Mathf.Ceil(damageRate * blastDamage);
                    healthScript.health -= damage;
                    if (healthScript.health <= 0)
                    {
                        Instantiate(woodBreakingPrefab, hitObject.transform.position, woodBreakingPrefab.transform.rotation);
                        Destroy(hitObject);
                    }
                }
            }
        }

        // Create SFX

        // Destroy bomb
        Destroy(gameObject);
    }
}