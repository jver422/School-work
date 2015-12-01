using UnityEngine;
using System.Collections;


public class TowerScript : MonoBehaviour {
    private bool onPath = false;
    private bool isSelected = false;
    private bool isPlanted = false;
    private bool canBePlanted = true;
	private float nextFire;
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
			if (Time.time > nextFire) 
			{
				nextFire = Time.time + rateOfFire;
            	fire();
			}
		}

		if (TR.Enemies.Count > 0) 
		{
			Vector3 TargetPosition = new Vector3 (TR.Enemies [0].transform.position.x, TR.Enemies [0].transform.position.y, 0);
			TargetPosition = TargetPosition - transform.position;
			float angle = Mathf.Atan2 (TargetPosition.y, TargetPosition.x) * Mathf.Rad2Deg - 180;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
        
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
       
        Instantiate(shot, spawn.position, spawn.rotation);
        
        Wait(rateOfFire / levelMultiplier);

    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);

        yield break;
    }
}
