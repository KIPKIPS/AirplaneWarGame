using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    // Start is called before the first frame update
    void Start() {
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*speed*Time.deltaTime);
        //超出边界 销毁游戏物体
        if (transform.position.y>4.4f) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag=="Enemy") {
            //敌人hp!=0才发送消息
            if (!other.GetComponent<Enemy>().isDead) {
                other.gameObject.SendMessage("BeHit");
                Destroy(this.gameObject);//销毁子弹
            }
        }
    }
}
