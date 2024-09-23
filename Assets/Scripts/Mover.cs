using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] public Vector3 direction;
    [SerializeField] public float speed;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
