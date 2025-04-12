using UnityEngine;

public class PO_Interactor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate net force acting on the object accounting all the other PhysicalObject2D in the scene
        Vector2 netForce = Vector2.zero;
        var all_objects = GameObject.FindObjectsByType<PhysicalObject2D>(FindObjectsSortMode.None);
        Vector2[] netforces = new Vector2[all_objects.Length];

        for (int i = 0; i < all_objects.Length; i++)
        {
            for (int j = 0; j < all_objects.Length; j++)
            {
                if (i != j)
                {
                    Vector2 direction = all_objects[j].transform.position - all_objects[i].transform.position;
                    float distance = direction.magnitude;
                    direction.Normalize();
                    float forceMagnitude = (all_objects[i].GetMass() * all_objects[j].GetMass()) / (distance * distance);
                    Vector2 force = direction * forceMagnitude;
                    netforces[i] += force;
                }
            }
        }


        for (int i = 0; i < all_objects.Length; i++)
        {
            all_objects[i].ApplyNetForce(netforces[i]);
        }
    }
}
