using UnityEngine;

public class PhysicalObject2D : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [HideInInspector] private float mass_ = 1.0f; // Point Mass of the object
    private Rigidbody2D rb_;
    void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        rb_.mass = mass_;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetMass()
    {
        return rb_.mass;
    }

    public void ApplyNetForce(Vector2 force)
    {
        rb_.AddForce(force);
    }
}
