using System;
using UnityEngine;

[Serializable] public class Boundary
{
    public float _xMinimum, _xMaximum, _yMinimum, _yMaximum;

}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Mover _mover;
    public Boundary _boundary;



    void Start()
    {
        _mover = GetComponent<Mover>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, Input.GetAxis("Vertical") * _speed * Time.deltaTime, transform.position.z);
        _mover.DoMove(movement);

        float x = Mathf.Clamp(transform.position.x, _boundary._xMinimum, _boundary._xMaximum);
        float y = Mathf.Clamp(transform.position.y, _boundary._yMinimum, _boundary._yMaximum);

        transform.position = new Vector3(x,y);
    }
}
