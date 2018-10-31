using UnityEngine;

public class StaticTurret : MonoBehaviour
{
    public GameObject laserPrefab;
    public float fireRate = 1;
    public bool useLineOfSight;

    float lastFireTime = float.MinValue;

    void Update()
    {
        GameObject player = Globals.playerObject;

        Vector3 dif = player.transform.position - transform.position;
        //Normalizing a vector returns a vector with the same direction but a length of 1
        dif.Normalize();//Effectively extracts the direction from a vector (when we don't care about its length)
        Vector3 gunDirection = transform.right;

        //The third important function with Vector Math is the Cross Product
        //The cross product between 2 vectors returns a vector that is perpendicular to the other 2.

        //The dot product between two vectors returns a scalar (single value instead of a vector)
        //representing a ratio of the angle between the two vectors
        //Two vectors pointing the same direction: 1
        //Two vectors pointing opposite each other: -1
        //Two vectors that are perpendicular: 0
        //dot = |a|*|b|*Cos(Θ)
        //So the angle Θ = Acos(dot)
        float dot = Vector3.Dot(dif, gunDirection);
        float angle = Mathf.Acos(dot);
        if (Mathf.Rad2Deg * angle < 30)//Cone of View (60 degrees)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 10);
            if (hit && hit.collider.gameObject == player)
            {
                if (Time.time - (1 / fireRate) > lastFireTime)
                {
                    Instantiate(laserPrefab, transform.position, transform.rotation);
                    lastFireTime = Time.time;
                }
            }
        }
    }
}
