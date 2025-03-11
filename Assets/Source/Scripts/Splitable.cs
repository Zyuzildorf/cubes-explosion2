using UnityEngine;

public class Splitable : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Rigidbody _rigidbody;

    public int SplitChance { get; private set; } = 100;
    public Rigidbody Rigidbody => _rigidbody;

    public void Init(int chanceOfNextSplit, Material newMaterial, Vector3 newScale)
    {
        if (newMaterial == null)
        {
            Debug.LogError("material is null");
            return;
        }

        if (newScale == Vector3.zero)
        {
            Debug.LogError("scale is zero");
            return;
        }
        
        _meshRenderer.material = newMaterial;
        SplitChance = chanceOfNextSplit;
        transform.localScale = newScale;
    }
}
