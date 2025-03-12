using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    
    public Material RandomizeMaterial()
    {
        Material newRandomMaterial = _materials[Random.Range(0, _materials.Count)];

        return newRandomMaterial;
    }
}