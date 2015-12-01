using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
    public void OnClick()
    {
        Application.LoadLevel("RandScene2");
    }
}
