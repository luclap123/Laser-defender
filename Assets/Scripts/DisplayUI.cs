using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DisplayUI : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start() {
        healthSlider.maxValue = playerHealth.getHealth();
    }

    public void Update() {
        healthSlider.value = playerHealth.getHealth();
        scoreText.text = scoreKeeper.getScore().ToString("000000000");
    } 

}
