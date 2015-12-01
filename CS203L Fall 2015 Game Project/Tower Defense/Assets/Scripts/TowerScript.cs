﻿using UnityEngine;
using System.Collections;


public class TowerScript : MonoBehaviour {
    private bool onPath = false;
    private bool isSelected = false;
    private bool isPlanted = false;
    private bool canBePlanted = true;
    public float rateOfFire = 0.5f;
    public int levelMultiplier = 1;
    public GameObject shot;
    public Transform spawn;

    TowerRange TR;

	// Use this for initialization
	void Awake () 
    {
        TR = GetComponentInChildren<TowerRange>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isSelected && !isPlanted)
        {
            transform.position = Input.mousePosition;
        }

        if (TR.Enemies.Count > 0)
        {
            fire();
        }


        Vector3 TargetPosition = new Vector3(TR.Enemies[0].transform.position.x, TR.Enemies[0].transform.position.y, 0);
        TargetPosition = TargetPosition - transform.position;
        float angle = Mathf.Atan2(TargetPosition.y, TargetPosition.x) * Mathf.Rad2Deg-180;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
	}

    void OnMouseDown()
    {
        Debug.Log("HI");
        if(isSelected)
        {
            isPlanted = true;
        }
        isSelected = true;

    }

    void OnMouseUp()
    {
        isSelected = false;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Path")
            canBePlanted = false;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        canBePlanted = true;
    }

    void fire()
    {
        //finds the first enemy and assigns the target 
        //if (target == null) target = TR.Enemies[0].transform;

        //for (int i = 0; i < TR.Enemies.Count; i++)
        //{
        //    if (target.gameObject.GetComponent<EnemyController>().time < TR.Enemies[i].GetComponent<EnemyController>().time)
        //        target = TR.Enemies[i].transform;
        //}
        //Debug.Log("Triggered");
        //instantiate projectile code here
        Instantiate(shot, spawn.position, spawn.rotation);
        
        Wait(rateOfFire / levelMultiplier);

    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);

        yield break;
    }
}