using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
	void Start ()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 3000);
        gameObject.GetComponent<Rigidbody2D>().AddTorque(10* Random.Range(-15,15));
    }

    void Update()
    {
        //By having this script check the Health object, it can do custom things when
        //death or other events occur, instead of handling this in the health script and then
        //needing multiple different Health scripts for different objects.
        if (GetComponent<Health>().IsDead())
            Destroy(gameObject);
    }
}
