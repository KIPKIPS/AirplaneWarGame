using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int score;

    public static GameManager _instance;

    public Text text;
    // Start is called before the first frame update
    void Awake() {
        _instance = this;
    }
    void Start() {
        score = 0;
        text = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        text.text = "Your Score: " + score;
    }
}
