using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {
    public float x;
    public float y;
    public float z;
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            other.GetComponent<BallHandler>().vel = new Vector3(x, y, z);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
