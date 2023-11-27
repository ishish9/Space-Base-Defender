using UnityEngine;

public class DestroyEffects : MonoBehaviour
{
    [SerializeField] private bool DestroyIn2;
    [SerializeField] private bool DestroyIn5;
    [SerializeField] private int DestroyObjectIn;

    void Start()
    {
        if (DestroyIn2)
        {
            Destroy(gameObject, 2f);
        }

        if (DestroyIn5)
        {
            Destroy(gameObject, 5f);
        }

        switch (DestroyObjectIn)
        {
            case 1:
                Destroy(gameObject, 1f);
                break;

            case 2:
                Destroy(gameObject, 2f);
                break;

            case 3:
                Destroy(gameObject, 3f);
                break;

            case 4:
                Destroy(gameObject, 4f);
                break;

            case 5:
                Destroy(gameObject, 5f);
                break;

            case 6:
                Destroy(gameObject, 6f);
                break;
        }
    }
}
