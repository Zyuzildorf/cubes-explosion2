using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplodableObjectsFinder : MonoBehaviour
{
    private float _radius = 20f;

    public List<Rigidbody> GetExplodableObjects(Vector3 explosionCenter)
    {
        List<Collider> colliders;
        List<Rigidbody> rigidbodies = new List<Rigidbody>();
        
        colliders = Physics.OverlapSphere(explosionCenter, _radius).ToList();

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbodies.Add(rigidbody);
            }
        }
        
        return rigidbodies;
    }
}