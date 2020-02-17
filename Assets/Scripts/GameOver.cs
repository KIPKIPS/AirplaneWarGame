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
        float highestScore = PlayerPrefs.GetFloat("highestScore", 0);//将最高分默认值设置为0
        //破纪录
        if (currentScore>highestScore) {
            PlayerPrefs.SetFloat("highestScore", currentScore);//修改最高分
        }
        //分数显示
        highestScoreText.text = highestScore + "";
        currentScoreText.text = currentScore + "";

        Camera.main.GetComponent<AudioSource>().Stop();//BGM停止
    }
}
