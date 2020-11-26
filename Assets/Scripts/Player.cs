using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D MyRigidBody;


    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MyRigidBody.velocity = Vector2.up * speed;
        }
    }
}
