using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    public string levelName;

	// Use this for initialization
    public void OnClick()
    {
        Application.LoadLevel(levelName);
        GameController.EnemySpeed = 1.0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
