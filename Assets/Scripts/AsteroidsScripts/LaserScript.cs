using UnityEngine;

public class LaserScript : MonoBehaviour
{
	void Start ()
    {
        Invoke("DieOff", 2);//Handy function for calling another function after x seconds

        //Addforce doesn't work for a Kinematic rigid body, but you can change its velocity directly.
        gameObject.GetComponent<Rigidbody2D>().velocity = (10 * gameObject.transform.right);
	}
	
	void Update ()
    {

	}

    void DieOff()
    {
        Destroy(gameObject);
    }
}
