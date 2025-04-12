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
        // Update the position of the object based on its velocity and acceleration
        Vector2 position = transform.position;
        position += velocity_ * Time.deltaTime;
        transform.position = position;

        // Reset acceleration for the next frame
        acceleration_ = Vector2.zero;
    }

    public float GetMass()
    {
        return mass_;
    }

    public void ApplyNetForce(Vector2 force)
    {
        // Apply a net force to the object
        Vector2 netForce = force / mass_;
        acceleration_ += netForce;
        velocity_ += acceleration_ * Time.deltaTime;
    }
}
