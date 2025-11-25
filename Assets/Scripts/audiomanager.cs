using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicsource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip splash;
    public AudioClip death;
    public AudioClip timer;

    private void Start()
    {
        musicsource.clip = background;
        musicsource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopSFX(AudioClip clip)
    {
        SFXSource.Stop();
    }

}
