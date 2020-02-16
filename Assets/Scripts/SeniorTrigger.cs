using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeniorTrigger : MonoBehaviour {
    public Hero hero;
    // Start is called before the first frame update
    void Start() {
        hero = GameObject.Find("Player").GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        //碰撞敌人
        if (other.tag == "Enemy") {
            hero.hp--;
            //Debug.Log(hero.hp);
        }
    }
}
