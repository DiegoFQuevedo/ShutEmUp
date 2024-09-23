using System;
using UnityEngine;

//ToDo: shoot system changes - multiples _shootOrigin's (maybe a list) can switch beetween "x" modes.
//      Modes: - Single shot
//             - Mulpliple shots
//             - 

[Serializable] public class Boundary
{
    public float _xMinimum, _xMaximum, _yMinimum, _yMaximum;
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _shootOrigin;
    [SerializeField] private GameObject _shootPrefab;

    public Boundary _boundary;


    void Start()
    {
        _mover.speed = _speed;
        InputProvider.OnHasShoot += OnHasShoot;
        InputProvider.OnDirection += OnDirection;
    }

    void Update()
    {
        PlayerMovement();
    }

    private void OnHasShoot() 
    {
        Instantiate(_shootPrefab, _shootOrigin, false);
    }

    private void OnDirection(Vector3 direction) 
    {
        _mover.direction = direction;
    }


    private void PlayerMovement() 
    {
        float x = Mathf.Clamp(transform.position.x, _boundary._xMinimum, _boundary._xMaximum);
        float y = Mathf.Clamp(transform.position.y, _boundary._yMinimum, _boundary._yMaximum);
        transform.position = new Vector3(x, y);
    }
}
