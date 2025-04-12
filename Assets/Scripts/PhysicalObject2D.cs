using UnityEngine;

public class PhysicalObject2D : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float mass_ = 1.0f; // Point Mass of the object
    [SerializeField] private Vector2 velocity_ = Vector2.zero; // Velocity of the object
    [SerializeField] private Vector2 acceleration_ = Vector2.zero; // Acceleration of the object
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate net force acting on the object accounting all the other PhysicalObject2D in the scene
        Vector2 netForce = Vector2.zero;
        var allObjects = GameObject.FindObjectsByType<PhysicalObject2D>(FindObjectsSortMode.None);
        foreach (PhysicalObject2D other in allObjects)
        {
            if (other != this)
            {
                Vector2 direction = other.transform.position - transform.position;
                float distance = direction.magnitude;
                direction.Normalize();
                float forceMagnitude = (mass_ * other.mass_) / (distance * distance); // Gravitational force
                netForce += forceMagnitude * direction;
            }
        }

        // Calculate acceleration using Newton's second law: F = m * a => a = F / m
        acceleration_ = netForce / mass_;
        // Update velocity using the acceleration
        velocity_ += acceleration_ * Time.deltaTime;
        // Update position using the velocity
        transform.position += (Vector3)velocity_ * Time.deltaTime;
    }

    float GetMass()
    {
        return mass_;
    }

}
