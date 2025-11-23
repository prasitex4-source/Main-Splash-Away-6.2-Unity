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

    private void Start()
    {
        musicsource.clip = background;
        musicsource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
