using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform player;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        Vector3 newPosition = player.position;
        newPosition.z = gameObject.transform.position.z;
        gameObject.transform.position = newPosition;
	}
}
