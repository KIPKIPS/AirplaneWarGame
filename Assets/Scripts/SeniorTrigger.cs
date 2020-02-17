using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeniorTrigger : MonoBehaviour {
    public Hero hero;
    public Text hpText;
    // Start is called before the first frame update
    void Start() {
        hero = GameObject.Find("Player").GetComponent<Hero>();
        hpText = GameObject.Find("HP").GetComponent<Text>();
        hpText.text= "HP : " + hero.hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        //碰撞敌人
        if (other.tag == "Enemy") {
            hero.hp--;
            hpText.text = "HP : " + hero.hp;
            //Debug.Log(hero.hp);
        }
    }
}
