using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ship_Manager : MonoBehaviour
{
    public GameObject target;
    public Transform look;
    void Update()
    {
        //transform.LookAt(look, Vector3.right);
        transform.RotateAround(target.transform.position, Vector3.left, 5 * Time.deltaTime);
        //transform.Rotate(0f, 0f, 300f * Time.deltaTime, Space.Self);
    }
}
