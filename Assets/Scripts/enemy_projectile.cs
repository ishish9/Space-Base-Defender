using UnityEngine;

public class enemy_projectile : MonoBehaviour
{
    private Rigidbody rb;
    public static bool impact = false;
    public GameObject[] ImpactEffect;
    public static int impactSelect = 0;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Rotate(0f, 0f, 300f * Time.deltaTime, Space.Self);
    }

    void OnCollisionEnter()
    {
        AsteroidScore.score += 1;
        Instantiate(ImpactEffect[impactSelect], transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
