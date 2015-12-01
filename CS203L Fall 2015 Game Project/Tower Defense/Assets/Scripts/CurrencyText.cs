using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Money;

public class CurrencyText : MonoBehaviour {
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        UpdateText(0);
    }

    void OnEnable()
    {
        Currency.CurrencyChanged += UpdateText;
    }

    void OnDisable()
    {
        Currency.CurrencyChanged -= UpdateText;
    }

    void UpdateText(int currentCurrency)
    {
        text.text = "Money: $" + currentCurrency;
    }
}
