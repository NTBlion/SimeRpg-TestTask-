using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    public void Move()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
}
