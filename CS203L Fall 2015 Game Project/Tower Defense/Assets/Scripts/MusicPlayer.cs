using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        SetVolume();
    }

    void OnEnable()
    {
        VolumeController.MusicVolumeChanged += SetVolume;
    }

    void OnDisable()
    {
        VolumeController.MusicVolumeChanged -= SetVolume;
    }
    private void SetVolume()
    {
        audio.volume = GameController.MusicVolume;
    }
}
