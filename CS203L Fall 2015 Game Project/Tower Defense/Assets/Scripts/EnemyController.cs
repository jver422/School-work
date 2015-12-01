using UnityEngine;
using System.Collections;
using Money;

public class EnemyController : MonoBehaviour
{
    //The Enemy's look and collider
    public float maxHealth = 1;
    public double currentHealth;
    public int damage = 1;
    public float speed = 1;
    public int money = 1;
    private Transform lifebarSprite;
    public float maxWidth = 40;
    public float direction = 0f;
    public double time = 0;

    void Start()
    {
        lifebarSprite = GetComponentInChildren<Transform>();
        currentHealth = maxHealth;
    }
//  
    void Update()
    {
        Move();
        time += Time.deltaTime * speed;
    }

    void Move()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float xspeed = Mathf.Cos(direction * Mathf.PI / 180f) * speed * GameController.EnemySpeed;
        float yspeed = Mathf.Sin(direction * Mathf.PI / 180f) * speed * GameController.EnemySpeed;
        rb.velocity = new Vector2(xspeed, yspeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Turn Right")
        {
            direction += 270f;
        }

        else if (col.gameObject.tag == "Turn Left")
        {
            direction += 90f;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        float xscale = (float)currentHealth / (float)maxHealth;
        Debug.Log(xscale);
        lifebarSprite.localScale = new Vector3(xscale, 1f, 1f);
        if (currentHealth <= 0)
        {
            Currency.increaseCurrency(money);
            Destroy(this);
        }
    }

    void OnGUI()
    {
        float currentWidth = maxWidth * ((float)currentHealth / (float)maxHealth);
        float x = transform.localPosition.x;
        float y = transform.localPosition.y;
    }

    public double DealDamage()
    {
        Destroy(gameObject);
        return damage;
    }
   
    public void EnemyStats(int level = 1, float haste = .5f, float durability = .5f)
	{
        // Precondition Lv >= 1 and the other two are 0 <= x < 1
        // the doubles will typically be generated from Random class's 
        // the following but makes sure the above is true
        if (level < 1)
        {
            level = 1;
        }
        if (haste < 0)
        {
            haste *= -1;
        }
        if (durability <= 0)
        {
            durability *= -1;
        }
        while (haste > 1)
        {
            haste /= 2.0f;
        }
        while (durability > 1)
        {
            durability /= 2.0f;
        }
        
        // actual code
        money = (int)Mathf.Pow(level, .5F);
        speed = haste + .5f;
        maxHealth = Mathf.Round(level * durability / speed);
        if (maxHealth < 1)
            maxHealth = 1;
        damage = (int)(level / (maxHealth * speed));
        if (damage < 1)
            damage = 1;
        speed *= 3 * Mathf.Log10(level+10);
    }
}