using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCapsule : MonoBehaviour
{
    private float force = 10f;
    private Rigidbody rb;
    private GameObject player;
    public GameObject EnergyExplode;
    public static bool isDead = false;

    void Start()
    {
        Destroy(gameObject, 20f);
        if (isDead == true)
        {
            Destroy(gameObject);
        }
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Enemy_Target");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector3(direction.x, direction.y, direction.z).normalized * force;
    }

    void Update()
    {
        transform.Rotate(0f, 2f, 0f * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter()
    {
        Instantiate(EnergyExplode, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
