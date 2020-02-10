using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float fireSpeed;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start() {
        fireSpeed = 0.2f;
        OpenFire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire() {
        //实例化一个子弹,位置为当前游戏物体位置,旋转角度为默认Quaternion.identity
        GameObject.Instantiate(bullet,transform.position,Quaternion.identity);
    }

    public void OpenFire() {
        InvokeRepeating("Fire",1,fireSpeed);
    }
}
