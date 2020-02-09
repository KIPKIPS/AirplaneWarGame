using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public bool canPlayAnim;//是否播放动画
    public int fps = 10;//fps
    public float timer=0;

    public Sprite[] sprites;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start() {
        canPlayAnim = true;
        sr = GetComponent<SpriteRenderer>();
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
    }

}
