using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerRange : MonoBehaviour {

    public List<GameObject> Enemies;
    public GameObject shot;
    public Transform spawn;
    public int fireRate;
	// Use this for initialization
	void Awake () 
    {
	    Enemies = new List<GameObject>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Enemies.Add(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Enemies.Remove(col.gameObject);
        }
        if (col.tag == "Projectile")
        {
            Destroy(col.gameObject);
        }
    }
}
