using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        Umbrella, StrengthBoost, Health
    }

    public PickupType pickupType;

    public void OnPickup(GameObject gameObject)
    {
        Collider2D col = GetComponent<Collider2D>();
        Destroy(col);

        switch (pickupType)
        {
            case PickupType.Umbrella:
                gameObject.GetComponent<Rigidbody2D>().gravityScale *= .5f;
                PlayerPrefs.SetInt("HasUmbrella", 1);
                PlayerPrefs.Save();
                break;
            case PickupType.StrengthBoost:
                break;
            case PickupType.Health:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == Globals.playerObject)
        {
            transform.parent = col.gameObject.transform;
            OnPickup(col.gameObject);           
        }
    }
}
