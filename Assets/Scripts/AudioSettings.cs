using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private static readonly string MusicVolumePref = "MusicVolumePref";
    private float musicVolume;
    public AudioSource musicVolumeAudio;
    public Slider musicVolumeSlider;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        musicVolume = PlayerPrefs.GetFloat(MusicVolumePref);
        musicVolumeAudio.volume = musicVolume;
        musicVolumeSlider.value = musicVolume;
    }

    public void UpdateSound()
    {
        musicVolumeAudio.volume = musicVolumeSlider.value;
    }
}
