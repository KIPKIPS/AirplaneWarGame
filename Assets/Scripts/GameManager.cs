using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum GameState {
    Running, Pause,End
}
public class GameManager : MonoBehaviour {
    public int score;
    public static GameManager _instance;
    public Text scoreText;
    public GameState gameState;

    public int highestScore;
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
        if (gameState==GameState.End) {
            GameOver._instance.Show(score);//显示结束界面
        }
    }

    public void ChangeState() {
        if (_instance.gameState == GameState.Running) {
            Pause();
            //_instance.gameState = GameState.Pause;
        }
        else if (_instance.gameState == GameState.Pause) {
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

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Exit() {
        Application.Quit();
    }
}
