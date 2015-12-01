using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultyManager : MonoBehaviour {
    public string[] difficultyNames;
    public Color[] difficultyColor;
    public int minDifficulty = 0;
    public int maxDifficulty = 3;
    public Text DifficultyText;
	// Use this for initialization
	void Start () {
        UpdateText();
	}

    private void UpdateText()
    {
        int index = GameController.Difficulty;
        DifficultyText.text = difficultyNames[index];
        DifficultyText.color = difficultyColor[index];
    }

    public void IncreaseDifficulty()
    {
        if (GameController.Difficulty < maxDifficulty)
        {
            GameController.Difficulty++;
            UpdateText();
        }
    }

    public void DecreaseDifficulty()
    {
        if (GameController.Difficulty > minDifficulty)
        {
            GameController.Difficulty--;
            UpdateText();
        }
    }
}
