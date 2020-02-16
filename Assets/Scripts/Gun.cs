using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float fireSpeed=0.1f;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start() {
        fireSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire() {
        //实例化一个子弹,位置为当前游戏物体位置,旋转角度为默认Quaternion.identity
        Instantiate(bullet,transform.position,Quaternion.identity);
        //Debug.Log("bullet 0");
    }

    public void OpenFire() {
        InvokeRepeating("Fire",0.5f,fireSpeed);
    }

    public void StopFire() {
        CancelInvoke("Fire");
    }
}
