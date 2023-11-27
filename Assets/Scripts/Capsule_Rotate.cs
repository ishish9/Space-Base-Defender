using UnityEngine;

public class Capsule_Rotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0f, 200f * Time.deltaTime, 0f, Space.Self);
    }
}
