using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    public bool animation;
    public int frameCountPerSecond = 10;
    public float timer=0;

    public Sprite[] sprites;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start() {
        animation = true;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animation) {
            timer += Time.deltaTime;
            int frameIndex = (int)(timer / (1.0f / frameCountPerSecond));
            frameIndex %= 2;
            sr.sprite = sprites[frameIndex];
        }
    }
}
