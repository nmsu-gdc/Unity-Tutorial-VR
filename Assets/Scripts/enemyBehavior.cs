using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    public float maxDistFromWall;
    public float moveForce;
    public Vector3 moveDir;
    public LayerMask whatIsWall;

    private Rigidbody rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(moveDir);
    }

    void Update()
    {
        rbody.velocity = moveDir * moveForce;
        moveDir = transform.forward;
        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
