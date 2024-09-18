using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public void DoMove(Vector3 moverValue) 
    {
        transform.Translate(moverValue);
    }
}
