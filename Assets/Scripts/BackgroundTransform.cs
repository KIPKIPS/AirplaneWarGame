using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTransform : MonoBehaviour {
    public static float moveSpeed;
    // Start is called before the first frame update
    void Start() {
        moveSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down*moveSpeed*Time.deltaTime);
        if (transform.position.y<=-8.52f) {
            transform.position += new Vector3(0, 17.04f, 0);
        }
    }
}
