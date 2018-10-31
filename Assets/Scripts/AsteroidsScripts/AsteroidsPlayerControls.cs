using UnityEngine;

public class AsteroidsPlayerControls : MonoBehaviour
{
    public float speed = 2;
    public GameObject laser;
    public float fireRate = 2;//lasers per second

    private float lastFireTime = float.MinValue;

	void Start ()
    {
        //For testing framerate-independence
        //Application.targetFrameRate = 100;
	}
	
    //Use FixedUpdate for rigidbody movement to prevent jitter
	void FixedUpdate ()
    {
        //To get Framerate-Independent gameplay, we need to factor in deltaTime
        //deltaTime is how much time has passed since the last frame.

        //Debug.Log(Time.deltaTime);

        Rigidbody2D rB = gameObject.GetComponent<Rigidbody2D>();
        //rB.velocity = Vector2.zero;//Zero out velocity every frame, so no momentum

        rB.AddForce(Input.GetAxis("Vertical") * speed * gameObject.transform.right);
        //if (Input.GetKey(KeyCode.W))
        {
           // rB.velocity = gameObject.transform.right * speed;
            //gameObject.transform.position += speed * gameObject.transform.right * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            //rB.AddTorque(5);//Notice we don't need Time.deltaTime if we use the rigid body to move
            gameObject.transform.Rotate(0, 0, 100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
            gameObject.transform.Rotate(0, 0, -100 * Time.deltaTime);       
    }

    void Update()
    {
        if (laser == null)
            Debug.Log("You forgot to hook a laser prefab into this variable dummy!");
        else if (Input.GetAxis("Laser") > 0)
        {
            if(Time.time - (1/fireRate) > lastFireTime)
            {
                GameObject obj = Instantiate(laser, transform.GetChild(0).position, transform.rotation);
                //Hue Saturation Value
                //Hue - color 
                //Saturation - how much color
                //Value - lightness/darkness
                obj.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
                lastFireTime = Time.time;
            }
        }
    }
}
