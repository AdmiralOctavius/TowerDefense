using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount = 10;
    public GameObject explosionPrefab;
     
    void OnAnyCollision(GameObject collidingObj, Vector3 collisionPoint)
    {
        //Damage the thing (needs to check if it has Health first; otherwise will throw an error if it hits something that doesn't)
        collidingObj.gameObject.GetComponent<Health>().ChangeHealth(-damageAmount);

        //Make pretty explosions
        if (explosionPrefab)
        {
            GameObject temp = Instantiate(explosionPrefab, collisionPoint, transform.rotation);
            Color laserColor = GetComponent<SpriteRenderer>().color;
            ParticleSystem.MainModule particleSettings = temp.GetComponent<ParticleSystem>().main;
            particleSettings.startColor = new Color(laserColor.r, laserColor.g, laserColor.b);
        }

        //Destroy this projectile
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        OnAnyCollision(col.gameObject, transform.position);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        OnAnyCollision(col.gameObject, col.contacts[0].point);
    }
}
