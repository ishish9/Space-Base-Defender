using UnityEngine;

public class PlanetRotate : MonoBehaviour
{ 

    void Update()
    {
        transform.Rotate(0f, 2f * Time.deltaTime, 0f, Space.Self);
    }
}
