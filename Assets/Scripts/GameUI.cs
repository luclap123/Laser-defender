using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    // Start is called before the first frame update

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        scoreText.text = "Your score is: \n" + scoreKeeper.getScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
