using UnityEngine;
using System.Collections;
using Money;

public class EnemyController : MonoBehaviour
{
    //The Enemy's look and collider
    public GameObject Enemyprefab;
    public double EnemyHealth;
    public double EnemyDamage;
    public double EnemySpeed;
    public int EnemyWorth;

//    private double EnemyAttaker();
    
//    void EnemyDamager(/*double PlayerDamage*/);


    //Track for collision, and depending on the other object collided with, we do something
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnemyAttacker();
        }
        if (other.tag == "Path")
        {
            //somesort of code to turn movement into another direction... will work on soon
        }
        if (other.tag == "Bullet")
        {

        }
    }

    //Called upon if enemy reaches player's defendable object, in which case, the player takes damage and the enemy is destroyed
    double EnemyAttacker()
    {
        //PlayerHealth -= EnemyDamage
        DestroyEnemy();
        //Temporary
        return 0.2;
    }

    //Used to get rid of the Enemy Gameobject
    void DestroyEnemy()
    {
        //currency.increaseCurrency(EnemyWorth);
        Destroy(gameObject);
    }

    //used to track Enemy Health
    void EnemyDamager(/*double PlayerDamage*/)
    {
        //EnemyHealth -= PlayerDamage
        if (EnemyHealth <= 0)
            DestroyEnemy();
        
    }

}