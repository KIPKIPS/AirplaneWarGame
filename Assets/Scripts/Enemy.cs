using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
    enemy0,
    enemy1,
    enemy2
}
public class Enemy : MonoBehaviour {
    public int hp;
    public float speed;

    public float destroyPosY;
    public EnemyType type = EnemyType.enemy0;
    public int score;

    public bool isDead;//是否死亡

    public Sprite[] sprites;
    public float timer;

    public int fps;
    public SpriteRenderer SR;

    // Start is called before the first frame update
    void Start() {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        //运动
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        //销毁
        if (transform.position.y < destroyPosY) {
            Destroy(this.gameObject);
        }
        //爆炸动画
        if (isDead) {
            //最后一帧播放完成
            timer += Time.deltaTime;
            int frame = (int)(timer / (1.0f / fps));
            SR.sprite = sprites[frame];
            //加分
            if (frame==sprites.Length-1) {
                if (type == EnemyType.enemy0) {
                    GameManager._instance.score += 1;
                }
                if (type == EnemyType.enemy1) {
                    GameManager._instance.score += 2;
                }
                if (type == EnemyType.enemy2) {
                    GameManager._instance.score += 5;
                }
                Destroy(this.gameObject);
            }
        }

    }
    public void BeHit() {
        hp--;
        isDead = hp <= 0;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag=="PlayerSenior") {
            this.isDead = true;
        }
    }
}
