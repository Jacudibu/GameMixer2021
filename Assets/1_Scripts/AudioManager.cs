using JetBrains.Annotations;
using UnityEngine;
using Utility;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : SingletonBehaviour<AudioManager>
{
    private AudioSource _audioSource;

    [SerializeField] [CanBeNull] private AudioClip phoneVibrationSound;
    [SerializeField] [CanBeNull] private AudioClip phoneNotificationSound;
    [SerializeField] [CanBeNull] private AudioClip phoneMessageSound;
    [SerializeField] [CanBeNull] private AudioClip phoneResponseButtonSound;
    [SerializeField] [CanBeNull] private AudioClip phoneOpenSound;
    [SerializeField] [CanBeNull] private AudioClip phoneCloseSound;
    [SerializeField] [CanBeNull] private AudioClip wrongLoginSound;
    [SerializeField] [CanBeNull] private AudioClip loginButtonSound;
    [SerializeField] [CanBeNull] private AudioClip successfulLoginSound;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Play([CanBeNull] AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        _audioSource.PlayOneShot(clip);
    }

    public void PlayWrongLonginSound()
    {
        Play(wrongLoginSound);
    }
    
    public void PlaySuccessfulLoginSound()
    {
        Play(successfulLoginSound);
    } 
    
    public void PlayPhoneVibrationSound()
    {
        Play(phoneVibrationSound);
    }
    
    public void PlayPhoneNotificationSound()
    {
        Play(phoneNotificationSound);
    }
    
    public void PlayPhoneMessageSound()
    {
        Play(phoneMessageSound);
    }    
    
    public void PlayPhoneOpenSound()
    {
        Play(phoneOpenSound);
    }
    
    public void PlayPhoneCloseSound()
    {
        Play(phoneCloseSound);
    }
    
    public void PlayLoginButtonSound()
    {
        Play(loginButtonSound);
    }
    
    public void PlayPhoneResponseButtonSound()
    {
        Play(phoneResponseButtonSound);
    }
    
}
