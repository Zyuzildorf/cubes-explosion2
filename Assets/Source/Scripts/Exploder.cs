using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _force = 500f;
    [SerializeField] private float _radius = 20f;

    public void TriggerExplosion(Transform transform, List<Rigidbody> explodableObjects)
    {
        float newRadius = _radius / transform.localScale.magnitude;
        float newForce = _force / transform.localScale.magnitude;

        Explode(newForce, newRadius, transform.position,explodableObjects);
    }


    private void Explode(float force, float radius, Vector3 position, List<Rigidbody> explodableObjects)
    {
        foreach (Rigidbody explodableObject in explodableObjects)
        {
            explodableObject.AddExplosionForce(force, position, radius);
        }
    }
}