using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour 
{
    public int AttackPower = 0;
    public float speed;
    private Rigidbody2D rigi;
    void Start()
    {
       
    }

    void Update()
    {
        rigi=GetComponent<Rigidbody2D>();
        rigi.velocity=transform.right * -speed;

    }
}
