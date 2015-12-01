using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {
    private bool onPath = false;
    private bool isSelected = false;
    private bool isPlanted = false;
    private bool canBePlanted = true;
    public Transform target;
	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {

        if (isSelected && !isPlanted)
        {
            transform.position = Input.mousePosition;
        }

        /*
        Vector3 TargetPosition = new Vector3(target.position.x, target.position.y, 0);
        //Vector3 lookPos = Camera.main.ScreenToWorldPoint(transform.position); COMMENT THIS OUT!! IT WILL MESS YOU UP GIRL!!!
        TargetPosition = TargetPosition - transform.position;
        float angle = Mathf.Atan2(TargetPosition.y, TargetPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        */
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
}
