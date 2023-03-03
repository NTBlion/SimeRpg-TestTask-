using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        transform.position = player.transform.position + _offset;
    }
}
