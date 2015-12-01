using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
    public float Seconds;
    private float sec;
	// Use this for initialization
	void Awake() {
        sec = 0;
	}
	
	// Update is called once per frame
	void Update () {
        sec = sec + Time.deltaTime;

        if (sec >= Seconds)
        {
            GetComponent<Animation>().Play();
        }
	}
}
