using JetBrains.Annotations;
using UnityEngine;
using Utility;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : SingletonBehaviour<AudioManager>
{
    private AudioSource _audioSource;

    [SerializeField] [CanBeNull] private AudioClip phoneVibrationSound;
    [SerializeField] [CanBeNull] private AudioClip phoneNotificationSound;
    [SerializeField] [CanBeNull] private AudioClip phoneOpenMessageReceivedSound;
    [SerializeField] [CanBeNull] private AudioClip phoneOpenMessageSentSound;
    [SerializeField] [CanBeNull] private AudioClip phoneOpenSound;
    [SerializeField] [CanBeNull] private AudioClip phoneCloseSound;
    [SerializeField] [CanBeNull] private AudioClip wrongLoginSound;
    [SerializeField] [CanBeNull] private AudioClip loginButtonSound;
    [SerializeField] [CanBeNull] private AudioClip successfulLoginSound;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Play([CanBeNull] AudioClip clip, float volumeScale = 1)
    {
        if (clip == null)
        {
            return;
        }

        _audioSource.PlayOneShot(clip, volumeScale);
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
    
    public void PlayPhoneOpenMessageSentSound()
    {
        Play(phoneOpenMessageSentSound, 0.02f);
    }
    
    public void PlayPhoneOpenMessageReceivedSound()
    {
        Play(phoneOpenMessageReceivedSound, 0.05f);
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
}
