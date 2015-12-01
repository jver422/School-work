using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
    public Text GameOverText;
	// Use this for initialization
	void Start () {
        StartCoroutine(YeahDelay());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator YeahDelay()
    {
        yield return new WaitForSeconds(1.3f);
        GameOverText.text += "\nYEEEEEAAAAH!!!";
    }
}
