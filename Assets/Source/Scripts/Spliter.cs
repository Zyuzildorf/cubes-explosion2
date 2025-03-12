using UnityEngine;
using Random = UnityEngine.Random;

public class Spliter : MonoBehaviour
{
    [SerializeField] private ExplodableObjectsFinder _explodableObjectsFinder;
    [SerializeField] private Splitable _template;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private ColorRandomizer _colorRandomizer;
    [SerializeField] private int _minNumberOfCubes = 2;
    [SerializeField] private int _maxNumberOfCubes = 6;
    [SerializeField] private int _reduceCoefficient = 2;

    private Vector2Int _minMaxRandomChance = new Vector2Int(0, 100);

    private void OnEnable()
    {
        _raycaster.OnObjectFound += OnObjectFound;
    }

    private void OnDisable()
    {
        _raycaster.OnObjectFound -= OnObjectFound;
    }

    private void OnObjectFound(Collider collider)
    {
        if (collider.TryGetComponent(out Splitable splitable))
        {
            if (TrySplitObject(splitable))
            {
                Split(splitable);
            }
            else
            {
                _exploder.TriggerExplosion(splitable.transform,
                    _explodableObjectsFinder.GetExplodableObjects(splitable.transform.position));
            }

            Destroy(splitable.gameObject);
        }
    }

    private bool TrySplitObject(Splitable splitable)
    {
        bool isObjectSplitting;
        int chance = Random.Range(_minMaxRandomChance.x, _minMaxRandomChance.y);

        if (chance < splitable.SplitChance)
        {
            isObjectSplitting = true;
        }
        else
        {
            isObjectSplitting = false;
        }

        return isObjectSplitting;
    }

    private void Split(Splitable splitable)
    {
        int amountNewCubes = Random.Range(_minNumberOfCubes, _maxNumberOfCubes);

        for (int i = 0; i < amountNewCubes; i++)
        {
            Splitable newSplittable = Instantiate(_template, splitable.transform.position, Quaternion.identity);
            newSplittable.Init(splitable.SplitChance / _reduceCoefficient, _colorRandomizer.RandomizeMaterial(),
                splitable.transform.localScale / _reduceCoefficient);
        }
    }
}