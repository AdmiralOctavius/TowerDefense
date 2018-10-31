using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public float patrolDistance = 4;

    //bool goingRight = true;

    // Vector3 startPosition;

    public Slider slider;
    public Vector3 startPoint, endPoint;
    float currentPercentage = 0;

    void Start ()
    {
        //startPosition = transform.position;
        startPoint = transform.GetChild(0).position;
        endPoint = transform.GetChild(1).position;
        slider = (Slider)gameObject.GetComponentInChildren(typeof(Slider));
    }
	
	void Update ()
    {
        //transform.position += new Vector3(goingRight ? .1f : -.1f, 0, 0);

        //if(Mathf.Abs(startPosition.x - transform.position.x) > patrolDistance)
        //    goingRight = !goingRight;

        currentPercentage = Mathf.PingPong(Time.time, 1);
        if(slider)
            slider.value = currentPercentage;
        transform.position = Vector3.Lerp(startPoint, endPoint, currentPercentage);
    }
}
