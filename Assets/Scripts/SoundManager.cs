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
            animationSource.PlayOneShot(sparedSound, 0.4f);
        }
    }

    public void PlayEnemyHitSound(AudioClip enemyHit)
    {
        if (!PauseManager.isPaused)
        {
            animationSource.PlayOneShot(enemyHit, 0.3f);
        }
    }

    public void PlayEnemyKilledSound(AudioClip enemyKilled)
    {
        if (!PauseManager.isPaused)
        {
            animationSource.PlayOneShot(enemyKilled, 1f);
        }
    }

    public void PlayPlayerHitSound(AudioClip playerHit)
    {
        if (!PauseManager.isPaused)
        {
            animationSource.PlayOneShot(playerHit, 0.5f);
        }

    }

    public void PlayPlayerKilledSound(AudioClip playerKilled)
    {
        if (!PauseManager.isPaused)
        {
            animationSource.PlayOneShot(playerKilled, 0.2f);
        }
    }

    public void PlayRespawnSound(AudioClip respawn)
    {
        if (!PauseManager.isPaused)
        {
            animationSource.PlayOneShot(respawn, 0.5f);
        }
    }

    /* TODO: 
        Blocking attack with push back
        Add main menu cutscene
        Add final npc dialogue which leads to main menu
        Make knockback random to make player have to move to hit
    */
}
