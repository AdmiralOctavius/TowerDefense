using UnityEngine;

public class SpriteSpin : MonoBehaviour
{
    float startXScale;
    float currentXScale;

    void Start()
    {
        startXScale = transform.localScale.x;
        currentXScale = startXScale;
    }

	void Update ()
    {
        currentXScale = Mathf.Sin(Time.time * 5) * startXScale;
        //currentXScale = Mathf.PingPong(Time.time, startXScale);
        transform.localScale = new Vector3(currentXScale, transform.localScale.y, transform.localScale.z);
	}
}
