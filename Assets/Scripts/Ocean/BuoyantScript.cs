using UnityEngine;

public class BuoyantScript : MonoBehaviour
{
    public float underwaterDrag = 3f;
    public float underwaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float buoyancyForce = 10;
    private Rigidbody thisRigidBody;
    private bool hasTouchedWater;
    void Awake()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check if underwater
        float diffY = transform.position.y;
        bool isUnderwater = diffY < 0;
        if (isUnderwater)
        {
            hasTouchedWater = true;
        }

        // Ignore if never touched water
        if (!hasTouchedWater)
        {
            return;
        }

        // Buoyancy logic
        if (isUnderwater)
        {
            Vector3 vector = Vector3.up * buoyancyForce * -diffY;
            thisRigidBody.AddForce(vector, ForceMode.Acceleration);
        }
        thisRigidBody.drag = isUnderwater ? underwaterDrag : airDrag;
        thisRigidBody.angularDrag = isUnderwater ? underwaterAngularDrag : airAngularDrag;
    }
}