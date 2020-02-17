using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public static GameOver _instance;
    public Text currentScoreText;
    public Text highestScoreText;
    void Awake() {
        currentScoreText = GameObject.Find("CurrentScore").GetComponent<Text>();
        highestScoreText = GameObject.Find("HistoryHighestScore").GetComponent<Text>();
        _instance = this;
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show(float currentScore) {
        this.gameObject.SetActive(true);
        float highestScore = PlayerPrefs.GetFloat("highestScore", 0);
        if (currentScore>highestScore) {
            PlayerPrefs.SetFloat("highestScore", currentScore);
        }
        highestScoreText.text = highestScore + "";
        currentScoreText.text = currentScore + "";
        
    }
}
