using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GameState {
    Running, Pause
}
public class GameManager : MonoBehaviour {
    public int score;
    public static GameManager _instance;
    public Text scoreText;

    public GameState gameState;
    
    // Start is called before the first frame update
    void Awake() {
        _instance = this;
        gameState = GameState.Running;
    }
    void Start() {
        score = 0;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "Your Score : " + score;
    }

    public void ChangeState() {
        if (_instance.gameState == GameState.Running) {
            Debug.Log("0");
            Pause();
            //_instance.gameState = GameState.Pause;
        }
        else if (_instance.gameState == GameState.Pause) {
            Debug.Log("1");
            Continue();
        }
    }
    //暂停
    public void Pause() {
        Time.timeScale = 0;
        _instance.gameState = GameState.Pause;
    }
    //继续游戏
    public void Continue() {
        Time.timeScale = 1;
        _instance.gameState = GameState.Running;
    }
}
