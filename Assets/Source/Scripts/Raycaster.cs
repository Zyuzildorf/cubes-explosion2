using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public event Action<Collider> OnObjectFound;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                OnObjectFound?.Invoke(hit.collider);
            }
        }
    }
}