using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != Globals.playerObject)
            return;

        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        Globals.playerObject.GetComponent<PlayerControls>().SetRespawnPoint(transform.position);

        foreach (Checkpoint c in Globals.staticCheckpoints)
        {
            if (c == this)
                continue;
            c.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {

    }
}
