using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onLook : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        if (cam == null) return;

        // Make the object face the camera
        transform.forward = cam.transform.forward;
    }
}
