using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    private AudioSource source;
    public AudioSource animationSource;

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
        animationSource.PlayOneShot(attackingSound, 0.3f);
    }
    
    //PlayEnemyHitSound

    //PlayEnemeyKilledSound

    //PlayedSparedSound
}
