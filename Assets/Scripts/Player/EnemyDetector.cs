using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayerMask;
    private float _radius = 10f;

    public event UnityAction EnemyDetected;

    private void Update()
    {
        var hitColliders = Physics.OverlapSphere(transform.position, _radius, _enemyLayerMask);

        if(hitColliders != null)
        {
            EnemyDetected?.Invoke();
        }
    }
}
