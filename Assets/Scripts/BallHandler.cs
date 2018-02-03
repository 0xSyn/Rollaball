using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallHandler : MonoBehaviour {
    public AudioSource sfx;
    public AudioClip aud_coin;
    public AudioClip aud_spring;
    public AudioClip aud_jump;
    public AudioClip aud_dmg;
    public float speed;
    
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;
    public Vector3 vel;
    void Awake() {
        sfx = GetComponent<AudioSource>();
        vel = new Vector3(0, 0, 0);
    }
    // Use this for initialization
    void Start () {
        //Physics.gravity.Set(0, 0, 0);
		rb = GetComponent<Rigidbody>();	
		count = 0;
		setCountText();
		winText.text="";
	}


	void Update() {
        rb.AddForce(1, -50, 1);
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(0, 1000, 0);
            sfx.clip = aud_jump;
            sfx.Play();
        }
	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		if(other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count++;
            sfx.clip = aud_coin;
            sfx.Play();
            setCountText();
		}
        else if (other.gameObject.CompareTag("Spring")) {
            sfx.clip = aud_spring;
            sfx.Play();
            rb.AddForce(vel.x, vel.y, vel.z);
        } 
        else if (other.gameObject.CompareTag("Spikes")) {
            sfx.clip = aud_dmg;
            sfx.Play();
           
        }
    }

	void setCountText() {
		countText.text = "Score: " + count.ToString();
		if(count>=12) {
			winText.text="You win!";
		}
	}


}