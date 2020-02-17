using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour {
    public int type;//0 gun / 1 boom
    public float speed;
    // Start is called before the first frame update
    void Start() {
        speed = 1.5f;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        //移动
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        //销毁
        if (transform.position.y<-4.8f) {
            Destroy(gameObject);
        }
    }
}
