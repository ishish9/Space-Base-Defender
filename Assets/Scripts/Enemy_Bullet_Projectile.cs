using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_Projectile : MonoBehaviour
{
    private float force = 20f;
    private GameObject player;
    private Rigidbody rb;
    public GameObject ProjectileExplodePrefab;
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
        rb.linearVelocity = new Vector3(direction.x, direction.y, direction.z).normalized * force;
    }

    void Update()
    {
        transform.Rotate(0f, 0f, 200f * Time.deltaTime, Space.Self);
    }

    void OnCollisionEnter()
    {
        Instantiate(ProjectileExplodePrefab, transform.position, Quaternion.identity);
        isDead = true;
        Destroy(gameObject);
    }
}
