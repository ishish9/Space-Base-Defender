using UnityEngine;

public class DetectShieldCapsule : MonoBehaviour
{
    public ShieldBar script1;
    public GameObject hbar;

    void OnCollisionEnter()
    {
        if (hbar.activeSelf == true)
        {
            script1.AddShield(10);
        }
    }
}
