﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Texture2D scope;
    [SerializeField] private float scopeSize;
    [SerializeField] private float sensivity = 3.0f;

    private float minY = -60.0f;
    private float maxY = 60.0f;

    private float rotationX;
    private float rotationY;

    private Quaternion originalRotation;

    private void Awake()
    {
        transform.GetComponent<Camera>().orthographic = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensivity;
        var QuaternionX = Quaternion.AngleAxis(rotationX, Vector3.up);

        rotationY += Input.GetAxis("Mouse Y") * sensivity;
        rotationY = ClampAngle(rotationY, minY, maxY);
        var QuaternionY = Quaternion.AngleAxis(rotationY, Vector3.left);

        transform.rotation = originalRotation * QuaternionX * QuaternionY;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        return Mathf.Clamp(angle, min, max);
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width - scopeSize) / 2, (Screen.height - scopeSize) / 2, scopeSize, scopeSize), scope);
    }
}
