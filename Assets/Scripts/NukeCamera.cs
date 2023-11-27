using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Transform look;

    void Update()
    {
        Vector3 desiredp = target.position + offset;
        Vector3 smoothedp = Vector3.Lerp(transform.position, desiredp, smoothSpeed * Time.deltaTime);
        transform.position = smoothedp;

        transform.LookAt(look, Vector3.right);
    }
}
