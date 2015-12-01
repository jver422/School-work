using UnityEngine;
using System.Collections;

public class FfwdButton : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if (GameController.EnemySpeed == 1.0f)
            GameController.EnemySpeed = 2.0f;
        else
            GameController.EnemySpeed = 1.0f;
    }
}