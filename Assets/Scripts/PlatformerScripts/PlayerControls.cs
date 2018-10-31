using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 0, walkSpeed = 5, sprintSpeed = 15;

    Vector2 respawnPoint;
    public GameObject umbrellaPrefab;
    public GameObject bulletPrefab;

    public void SetRespawnPoint(Vector2 vec)
    {
        respawnPoint = vec;
    }

	void Start ()
    {
        Globals.playerObject = gameObject;//4th way to reference a gameobject from another - have the gameobject tell the other one about itself instead of vice versa
        respawnPoint = transform.position;

        //Use this in a 'Start New Game' button or similar to get rid of the stored data
        //PlayerPrefs.DeleteAll();

        int result = 0;
        if (PlayerPrefs.HasKey("HasUmbrella"))
            result = PlayerPrefs.GetInt("HasUmbrella");
        if (result == 1)
        {
            //Should check if there is an umbrella already placed in the scene and delete that one
            GameObject umbrella = Instantiate(umbrellaPrefab, transform);
            umbrella.GetComponent<Pickup>().OnPickup(gameObject);
            umbrella.transform.localPosition = new Vector3(-1, 0, 0);
        }
	}

    void Update()//More responsive - checks our input each frame
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (transform.position.y <= -10)
        {
            rb.velocity = Vector2.zero;
            transform.position = respawnPoint;
        }

        if (Input.GetKey(KeyCode.LeftShift))
            speed = sprintSpeed;
        else
            speed = walkSpeed;

        //Calculate World Space mouse position and rotation towards it.
        Vector3 mousePosition = Input.mousePosition;//Screen space mouse position (like from 0,0 to 800,600 or whatever resolution is)
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);//Converted to world position
        mousePosition.z = transform.position.z;
        Quaternion rot = Quaternion.FromToRotation(Vector3.right, mousePosition - transform.position);

        //Parallaxing background is one in which different layers and sprites move at different rates
        //making it appear to be 3D even if they are all 2D sprites.
        //You can do that either by literally moving them with a script at different rates
        //Or make the camera a Perspective camera and move the objects in 3D on their z axis.

        //Rotates sword and fires bullets on mouse down toward mouse
        if (transform.GetChild(1))
        {
            //Scale flip
            if (mousePosition.x < transform.position.x)
                transform.GetChild(1).GetChild(0).localScale = new Vector3(1, -1);
            else
                transform.GetChild(1).GetChild(0).localScale = Vector2.one;

            //Spriterenderer flip
            //if (mousePosition.x < transform.position.x)
            //    transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
            //else
            //    transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().flipY = false;

            transform.GetChild(1).rotation = Quaternion.FromToRotation(Vector3.right, mousePosition - transform.position);

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Instantiate(bulletPrefab, transform.position, rot);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check if we are on the ground right now
            GameObject feet = transform.GetChild(0).gameObject;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.transform.position, .5f);
            foreach (Collider2D col in colliders)
            {
                //Don't jump off ourselves
                if (col.gameObject != this.gameObject)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);//Ignore previous falling velocity so we jump the full amount each time.
                                        
                    rb.AddForce(Vector2.up * 600);

                    break;
                }
            }
        }
    }
	void RestartCollider()
    {
        Collider2D col = GetComponent<Collider2D>();
        col.enabled = true;
    }
	void FixedUpdate ()
    {
        //Handle left and right movement
        float movement = Input.GetAxis("Horizontal") * speed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if(Input.GetKey(KeyCode.S))
        {
            Collider2D col = GetComponent<Collider2D>();
            col.enabled = false;
            Invoke("RestartCollider", .45f);
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (movement > 0)
            sr.flipX = false;
        else if(movement < 0)
            sr.flipX = true;

        Animator anim = GetComponent<Animator>();

        if (Mathf.Abs(movement - 0) > float.Epsilon)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);
    }
}
