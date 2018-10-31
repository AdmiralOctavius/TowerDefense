using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        gameObject.GetComponent<AudioSource>().volume = Mathf.Min(1, col.relativeVelocity.magnitude * .2f);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
