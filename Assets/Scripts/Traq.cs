using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traq : MonoBehaviour {

    GameObject playerObj;
    // Use this for initialization
    void Start() {
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        Vector3 offset = new Vector3(0f,0f,-10.0f);
        transform.position = playerObj.transform.position + offset;

	}
}
