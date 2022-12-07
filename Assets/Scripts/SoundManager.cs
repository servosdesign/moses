using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    private static readonly string FirstPlay = "FirstPlayer";
    private static readonly string MusicVolumePref = "MusicVolumePref";
    private int firstPlayInt;
    public Slider musicVolumeSlider;
    private float musicVolume;
    public AudioSource musicVolumeAudio;

    private AudioSource source;
    public AudioSource animationSource;

    public void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            musicVolume = 0.5f;
            musicVolumeSlider.value = musicVolume;
            PlayerPrefs.SetFloat(MusicVolumePref, musicVolume);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musicVolume = PlayerPrefs.GetFloat(MusicVolumePref);
            musicVolumeSlider.value = musicVolume;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MusicVolumePref, musicVolumeSlider.value);
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        musicVolumeAudio.volume = musicVolumeSlider.value;
    }

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound, 0.5f);
    }

    public void PlayWalkingSound(AudioClip footstepSound)
    {
        animationSource.PlayOneShot(footstepSound, 0.01f);
    }

    public void PlayAttackingSound(AudioClip attackingSound)
    {
        if (!PauseManager.isPaused)
        {
            animationSource.PlayOneShot(attackingSound, 0.3f);
        }
    }

    public void PlaySparedSound(AudioClip sparedSound)
    {
        if (!PauseManager.isPaused)
        {
            animationSource.PlayOneShot(sparedSound, 0.1f);
        }
    }

    //PlayEnemyHitSound

    //PlayEnemeyKilledSound

    //PlayPlayerHitSound

    //PlayPlayerKilledSound

    /* TODO: 
        Respawn Player when dies
        Make health 100 
        Increase range of skeletons
        Remove Health UI from pause menu
        Add main menu cutscene
        Add final npc dialogue which leads to main menu
    */
}
