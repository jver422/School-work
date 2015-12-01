using UnityEngine;
using System.Collections;

public class DefendableObject : MonoBehaviour {

    public delegate void ObjectDamageHandler(int currentHealth, int maxHealth);
    public event ObjectDamageHandler TakeDamage;
    public event ObjectDamageHandler Died;

    public int maximumHealth = 1000;
    private int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maximumHealth;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            //TODO: Get number of damage enemy can deal to defendable object
            //Replace -10
            currentHealth -= 10;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }

            if (TakeDamage != null)
                TakeDamage(currentHealth, maximumHealth);
            if (currentHealth == 0 && Died != null)
            {
                Died(currentHealth, maximumHealth);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (TakeDamage != null)
        {
            //TakeDamage(currentHealth--, maximumHealth);
        }
	}
}