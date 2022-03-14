using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.position += Vector3.forward*Time.deltaTime*speed;
    }
}
