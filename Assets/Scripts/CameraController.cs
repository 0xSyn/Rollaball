using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
    public AudioClip aud_bgm_0;
    //private AudioSource sfx;

    void Awake() {
        //sfx = GetComponent<AudioSource>();
        
    }
    // Use this for initialization
    void Start () {
		offset = transform.position - player.transform.position;
        //sfx.Play();
    }
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
