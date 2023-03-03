using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;
    [SerializeField] private float _disableOffsetZ;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnedGameObject = Instantiate(prefab, _container);
            spawnedGameObject.SetActive(false);

            _pool.Add(spawnedGameObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAboardScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0f, 0f));

        foreach (var item in _pool)
        {
            if (item.activeSelf)
                if (item.transform.position.z < disablePoint.z + _disableOffsetZ)
                    item.SetActive(false);
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
