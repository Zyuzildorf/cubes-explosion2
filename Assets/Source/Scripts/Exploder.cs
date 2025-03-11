using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _force = 500f;
    [SerializeField] private float _radius = 20f;

    public void TriggerExplosion(Transform transform)
    {
        float newRadius = _radius / transform.localScale.magnitude;
        float newForce = _force / transform.localScale.magnitude;
        
        Explode(newForce, newRadius, transform.position);
    }
    
    private void Explode(float force, float radius, Vector3 position)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects(radius))
        {
            explodableObject.AddExplosionForce(force, position, radius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(float radius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        List<Rigidbody> objects = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);
        }

        return objects;
    }
}