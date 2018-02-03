using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {
    CharacterController controller;
    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
    public bool active = false;
    // Use this for initialization
    void Start () {
		
	}
    void Awake() {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void FixedUpdate () {
        Debug.Log(active);
        if (active) {
            float tilt_Z = -Input.GetAxis("Horizontal") * tiltAngle;
            float tilt_X = Input.GetAxis("Vertical") * tiltAngle;
            Quaternion target = Quaternion.Euler(tilt_X, 0, tilt_Z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            active = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            active = false;
        }
    }



}
