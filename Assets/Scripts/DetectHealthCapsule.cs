using UnityEngine;

public class DetectHealthCapsule : MonoBehaviour
{
    public HealthBar script1;
    public GameObject hbar;

    void OnCollisionEnter()
    {
        if (hbar.activeSelf == true)
        {
            script1.AddHealth(10);
        }
    }
}
