using UnityEngine;

public class Projectile : MonoBehaviour
{
    //GameObject player;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * 10;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == Globals.playerObject)
        {
            SpriteRenderer sr = col.gameObject.GetComponent<SpriteRenderer>();
            sr.color = Color.Lerp(sr.color, Color.red, .1f);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
