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
    }

    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            Instantiate(_shootPrefab, _shootOrigin, false);
        }

        PlayerMovement();
    }

    private void PlayerMovement() 
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), transform.position.z);
        _mover.direction = direction;

        float x = Mathf.Clamp(transform.position.x, _boundary._xMinimum, _boundary._xMaximum);
        float y = Mathf.Clamp(transform.position.y, _boundary._yMinimum, _boundary._yMaximum);
        transform.position = new Vector3(x, y);
    }
}
