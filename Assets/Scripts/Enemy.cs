using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int hp;

    public float speed;

    public float destroyPosY;

    public int score;
    // Start is called before the first frame update
    void Start() {
        hp = 1;
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //运动
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        //销毁
        if (transform.position.y<destroyPosY) {
            Destroy(this.gameObject);
        }
    }
}
