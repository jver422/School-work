using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

    public Texture2D lifebarSprite;
    public DefendableObject defendableObject;
    public float maxWidth = 100f;
    private float currentWidth;

    void OnEnable()
    {
        if (defendableObject != null)
        {
            defendableObject.TakeDamage += UpdateLifebar;
        }
    }

    void OnDisable()
    {
        if (defendableObject != null)
        {
            defendableObject.TakeDamage -= UpdateLifebar;
        }
    }

	// Use this for initialization
	void Start () {
        currentWidth = maxWidth;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnGUI()
    {
        if (lifebarSprite != null)
        {
            GUI.DrawTexture(new Rect(10, 10, currentWidth, 50), lifebarSprite);
        }
    }

    void UpdateLifebar(int currentHealth, int maxHealth)
    {
        currentWidth = Mathf.Max(maxWidth * ((float)currentHealth / (float)maxHealth), 0f);
    }
}
