using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    private float initialRotation;

    void Start()
    {
        initialRotation = transform.rotation.z;
    }

    // called after Update() so Camera has already changed the position
    void LateUpdate()
    {
        //transform.LookAt(transform.position + cam.position);
        transform.rotation = cam.rotation;
        transform.Rotate(Vector3.up * initialRotation * 180); // fix
    }
}
