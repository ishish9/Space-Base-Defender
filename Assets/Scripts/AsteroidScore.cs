using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidScore : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI AsteroidScoreText;

    void Update()
    {
        AsteroidScoreText.text = score.ToString();
    }
}
