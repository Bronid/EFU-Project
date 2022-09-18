using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text scoreText;

    private void Update()
    {
        scoreText.text = ((int)(player.position.z / 2)).ToString();
    }
}
