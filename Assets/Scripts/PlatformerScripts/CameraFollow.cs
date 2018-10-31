using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;

    void Start ()
    {
	    	
	}	
	
    void Update ()
    {
		if(followObject)
        {
            //LARP - Live Action Role Play (unrelated to LERP)
            //LERP - Linear Interpolation
            //if 0 is min, 5 is max, then
            //0 would return 0
            //5 would return 1 (100% of the way between min and max)
            //2.5 would return .5 (50% of the way between min and max)

            //Smoothly approach the player
            transform.position = Vector3.Lerp(transform.position, new Vector3(followObject.transform.position.x,
                followObject.transform.position.y, transform.position.z), .1f);

            //Warp to the player
            //transform.position = new Vector3(followObject.transform.position.x, 
            //  followObject.transform.position.y, transform.position.z);
        }
    }
}
