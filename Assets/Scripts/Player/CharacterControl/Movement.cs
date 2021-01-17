using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 transfer;
    [SerializeField] private float speed = 3.0f;

    void Update()
    {
        var cameraForward = transform.GetComponentInChildren<MouseLook>().transform.forward;
        transform.forward = new Vector3(cameraForward.x, 0, cameraForward.z);

        transfer = transform.forward * Input.GetAxis("Vertical");
        transfer += transform.right * Input.GetAxis("Horizontal");

        transform.position += transfer * speed * Time.deltaTime;
    }
}
