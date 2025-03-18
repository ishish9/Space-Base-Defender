using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NukeLogic : MonoBehaviour
{
    private float force = 10f;
    private GameObject player;
    private Rigidbody rb;
    public GameObject ProjectileExplodePrefab;
    public GameObject target;
    public Transform other;
    public TextMeshProUGUI DistanceDisplay;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Enemy_Target");
    }

    void Update()
    {
        transform.Rotate(0f, 0f, 800f * Time.deltaTime, Space.Self);

        transform.RotateAround(target.transform.position, Vector3.left, 5 * Time.deltaTime);
        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector3(direction.x, direction.y, direction.z).normalized * force;

        float dist = Vector3.Distance(other.position, transform.position);
        DistanceDisplay.text = dist.ToString();
    }

    void OnCollisionEnter()
    {
        gameObject.SetActive(false);
        Instantiate(ProjectileExplodePrefab, transform.position, Quaternion.identity);
    }
}
