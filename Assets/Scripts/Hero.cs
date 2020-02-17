using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public float timer = 0;
    public float timerExplode = 0;
    public Sprite[] sprites;
    public Sprite[] spritesExplode;

    public SpriteRenderer sr;

    public float superWeaponTime = 15;
    private float restSuperWeaponTime;

    public int weaponCount = 1;//武器数量

    public Gun gunTop;
    public Gun gunLeft;
    public Gun gunRight;

    public int hp;
    public int boomRestNum;
    public Text boomText;

    public AudioSource[] audioList;
    void Awake() {
        gunTop = GameObject.Find("Gun_top").GetComponent<Gun>();
        gunLeft = GameObject.Find("Gun_left").GetComponent<Gun>();
        gunRight = GameObject.Find("Gun_right").GetComponent<Gun>();
        audioList = GetComponents<AudioSource>();
        boomText = GameObject.Find("RestNum").GetComponent<Text>();
        Dup = 0;
        Dright = 0;
    }
    // Start is called before the first frame update
    void Start() {
        gunTop.OpenFire();
        canPlayAnim = true;
        sr = GetComponent<SpriteRenderer>();
        //初始状态下武器为1
        restSuperWeaponTime = superWeaponTime;
        superWeaponTime = 0;
        boomRestNum = 0;
        boomText.text = "X 0";
    }

    // Update is called once per frame
    void Update() {
        //空格Down下 BoomBoomBoom!!!
        if (Input.GetKeyDown(KeyCode.Space)) {
            Boom();
        }
        if (canPlayAnim) {
            timer += Time.deltaTime;
            int frameIndex = (int)(timer / (1.0f / fps)) % 2;//1/fps=一帧所需时间 (timer/一帧所需时间)再取整得到当前帧索引
            //frameIndex %= 2;
            sr.sprite = sprites[frameIndex];
        }
        if (hp <= 0) {
            canPlayAnim = false;
            timerExplode += Time.deltaTime;
            int frameIndexExplode = (int)(timerExplode / (1.0f / fps)) % 4;
            sr.sprite = spritesExplode[frameIndexExplode];
            //最后一帧完成则Explode
            if (frameIndexExplode == spritesExplode.Length - 1) {
                GameManager._instance.gameState = GameState.End;
                //Time.timeScale = 0;
                DestroyAll();
                Time.timeScale = 0;
                Destroy(this.gameObject);
                
            }
        }
        targetDup = (Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0);
        targetDright = (Input.GetKey(keyRight) ? 1.0f : 0) - (Input.GetKey(keyLeft) ? 1.0f : 0);
        //对输入值进行插值计算
        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);//x AD
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);//y WS

        transform.Translate(new Vector3(Dright, Dup, transform.position.z) * moveSpeed * Time.deltaTime);
        //防止越界
        float x = Mathf.Clamp(transform.position.x, -1.8f, 1.8f);
        float y = Mathf.Clamp(transform.position.y, -3.66f, 3.66f);

        transform.position = new Vector3(x, y, transform.position.z);
        superWeaponTime -= Time.deltaTime;
        if (superWeaponTime > 0) {
            if (weaponCount == 1) {
                ToSuperWeapon();
            }
        }
        else {
            if (weaponCount == 2) {
                ToNormalWeapon();
            }
        }
    }
    //切换武器
    //super
    void ToSuperWeapon() {
        weaponCount = 2;
        gunTop.StopFire();
        gunRight.OpenFire();
        gunLeft.OpenFire();
    }
    //normal
    void ToNormalWeapon() {
        weaponCount = 1;
        gunTop.OpenFire();
        gunRight.StopFire();
        gunLeft.StopFire();
    }
    void OnTriggerEnter(Collider other) {
        //获取补给
        if (other.tag == "Award") {
            audioList[0].Play();
            //double weapon
            if (other.transform.GetComponent<Award>().type == 0) {
                superWeaponTime = restSuperWeaponTime;
            }
            //boom
            if (other.transform.GetComponent<Award>().type == 1) {
                //other.gameObject.SendMessage("GetAward1");
                boomRestNum++;
                boomText.text = "X " + boomRestNum;
            }
            Destroy(other.gameObject);
        }
    }

    void DestroyAll() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var VARIABLE in enemies) {
            Destroy(VARIABLE.gameObject);
        }
        GameObject[] awards = GameObject.FindGameObjectsWithTag("Award");
        foreach (var VARIABLE in awards) {
            Destroy(VARIABLE.gameObject);
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (var VARIABLE in bullets) {
            Destroy(VARIABLE.gameObject);
        }
        Destroy(GameObject.Find("Spawn").gameObject);
    }

    void Boom() {
        boomRestNum--;
        boomText.text = "X " + boomRestNum;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in gos) {
            //Debug.Log(go.name);
            go.GetComponent<Enemy>().isDead = true;
        }
    }
}
