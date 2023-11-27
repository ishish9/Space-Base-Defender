using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fire_System : MonoBehaviour
{
    [SerializeField] private Transform SpawnLocation;
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private int FireAmount = 10;
    [SerializeField] private float FireRate = .5f;
    [SerializeField] private Transform[] EnemyGunPositions;
    private int[] newPosition;

    public void Start()
    {
        EnemyGunPositions = new Transform[3];
        StartCoroutine(w1());

        IEnumerator w1()
        {
            for (int j = 0; j < FireAmount; j++)
            {
                yield return new WaitForSeconds(FireRate);

                Instantiate(ProjectilePrefab, SpawnLocation.position, Quaternion.identity);
            }
        }
    }
}
