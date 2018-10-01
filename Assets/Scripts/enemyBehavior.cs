﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{

    public float moveForce;
    private Rigidbody rbody;
    public Vector3 moveDir;
    public LayerMask whatIsWall;
    public float maxDistFromWall;

    void Start()
    {

        rbody = GetComponent<Rigidbody>();
        //moveDir = ChooseDirection();
        transform.rotation = Quaternion.LookRotation(moveDir);

    }

    // Update is called once per frame
    void Update()
    {

        rbody.velocity = moveDir * moveForce;



            moveDir = transform.forward;
            transform.rotation = Quaternion.LookRotation(moveDir);

    }
}
