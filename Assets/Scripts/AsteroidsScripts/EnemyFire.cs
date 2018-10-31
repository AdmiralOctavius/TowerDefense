using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject laser;
    public float fireRate = 2;//lasers per second
    private float lastFireTime = float.MinValue;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - (1 / fireRate) > lastFireTime)
        {
            GameObject obj = Instantiate(laser, transform.GetChild(0).position, transform.rotation);
            //Hue Saturation Value
            //Hue - color 
            //Saturation - how much color
            //Value - lightness/darkness
            obj.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0, 1, 0, 1);
            lastFireTime = Time.time;
        }
    }
}
