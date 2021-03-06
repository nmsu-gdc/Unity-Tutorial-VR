﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour 
{

    Vector2 mouseLook;
    Vector2 smoothV;
    GameObject character;
    Quaternion _initialOrientation; // Orientation state.
    Vector2 _currentAngles;
    CursorLockMode _previousLockState; // Cached cursor state.
    bool _wasCursorVisible;

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public float projectileSpeed;
    public GameObject emit;
    public Rigidbody projectile;
    
    void Start()
    {
        character = this.transform.parent.gameObject;

        // Cache our starting orientation as our center point.
        _initialOrientation = transform.localRotation;

        // Cache the previous cursor state so we can restore it later.
        _previousLockState = Cursor.lockState;
        _wasCursorVisible = Cursor.visible;

        // Hide & lock the cursor for that FPS experience
        // and to avoid distractions / accidental clicks
        // from the mouse cursor moving around.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxis("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Rigidbody iP = Instantiate(projectile, emit.transform.position, emit.transform.rotation) as Rigidbody;
            iP.AddForce(emit.transform.forward * projectileSpeed);
        }
    }
}