using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _homePosition;

    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distanceOffset = 0.5f;

    private Vector3 _currentTarget;
    private Vector3 _direction;

    private void Start()
    {
        ChangeDirection();
    }

    private void Update()
    {
        if (GetDistance() <= _distanceOffset)
            ChangeDirection();
        else
            Move();
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime); 
    }

    private void ChangeDirection()
    {
        _currentTarget = _currentTarget == _startPosition.position ? _homePosition.position : _startPosition.position;

        _direction = (_currentTarget - transform.position).normalized;
    }

    private float GetDistance()
    {
        return Vector3.Distance(_currentTarget, transform.position);
    }
}
