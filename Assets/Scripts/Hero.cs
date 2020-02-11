using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public float moveSpeed;
    //输入信号值
    public float Dup;
    public float Dright;
    //平滑输入值
    private float targetDup;
    private float targetDright;
    private float velocityDup;
    private float velocityDright;

    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";

    public bool canPlayAnim;//是否播放动画
    public int fps = 10;//fps
    public float timer=0;

    public Sprite[] sprites;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start() {
        canPlayAnim = true;
        sr = GetComponent<SpriteRenderer>();
        moveSpeed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlayAnim) {
            timer += Time.deltaTime;
            int frameIndex = (int)(timer / (1.0f / fps)) %2;//1/fps=一帧所需时间 (timer/一帧所需时间)再取整得到当前帧索引
            //frameIndex %= 2;
            sr.sprite = sprites[frameIndex];
        }
        targetDup = (Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0);
        targetDright = (Input.GetKey(keyRight) ? 1.0f : 0) - (Input.GetKey(keyLeft) ? 1.0f : 0);
        //对输入值进行插值计算
        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);//x AD
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);//y WS

        transform.Translate(new Vector3(Dright,Dup,transform.position.z)*moveSpeed*Time.deltaTime);
        //防止越界
        float x=Mathf.Clamp(transform.position.x, -1.8f, 1.8f);
        float y = Mathf.Clamp(transform.position.y, -3.66f, 3.66f);

        transform.position = new Vector3(x, y,transform.position.z);

    }

    void GetAward() {

    }

}
