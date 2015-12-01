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

    //void Update()
    //{
    //    Vector3 TargetPosition = new Vector3(Enemies[0].transform.position.x, Enemies[0].transform.position.y, 0);
    //    TargetPosition = TargetPosition - transform.position;
    //    float angle = Mathf.Atan2(TargetPosition.y, TargetPosition.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    //    if (Enemies.Count > 0)
    //        Fire();

    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Enemies.Add(col.gameObject);
        }
    }

    //void Fire()
    //{
    //    Instantiate(shot, spawn.position, spawn.rotation);

    //}

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
