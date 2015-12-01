using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeController : MonoBehaviour {
    public Text VolumeText;
    public Text MusicText;
    public AudioSource sampleSound;
    public delegate void MusicVolumeChangedHandler();
    public static event MusicVolumeChangedHandler MusicVolumeChanged;

	// Use this for initialization
	void Start () {
        UpdateVolume(false);
        UpdateMusic();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void UpdateVolume(bool playSound)
    {
        if (VolumeText != null)
            VolumeText.text = "Sound Volume\n" + Mathf.RoundToInt(GameController.GameVolume * 100).ToString() + "%";
        if (sampleSound != null)
            sampleSound.volume = GameController.GameVolume;
        if (playSound && sampleSound != null)
            sampleSound.Play();
    }

    private void UpdateMusic()
    {
        if (MusicText != null)
            MusicText.text = "Music Volume\n" + Mathf.RoundToInt(GameController.MusicVolume * 100).ToString() + "%";
    }
    public void IncreaseVolume()
    {
        if (GameController.GameVolume < 1.0f)
        {
            GameController.GameVolume += 0.05f;
            UpdateVolume(true);
        }
    }

    public void DecreaseVolume()
    {
        if (GameController.GameVolume > 0.0f)
        {
            GameController.GameVolume -= 0.05f;
            UpdateVolume(true);
        }
    }

    public void IncreaseMusic()
    {
        if (GameController.MusicVolume < 1.0f)
        {
            GameController.MusicVolume += 0.05f;
            UpdateMusic();
            if (MusicVolumeChanged != null)
            {
                MusicVolumeChanged();
            }
        }
    }

    public void DecreaseMusic()
    {
        if (GameController.MusicVolume > 0.0f)
        {
            GameController.MusicVolume -= 0.05f;
            UpdateMusic();
            if (MusicVolumeChanged != null)
            {
                MusicVolumeChanged();
            }
        }
    }
}