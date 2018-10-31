using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;

    private float health;
    private bool isDead;
     
	void Start ()
    {
        health = maxHealth;
        isDead = false;
	}
	 
	void Update ()
    {
		
	}

    public void ChangeHealth(float changeAmt)
    {
        health = Mathf.Min(health + changeAmt, maxHealth);
        if (health <= 0)
            isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
