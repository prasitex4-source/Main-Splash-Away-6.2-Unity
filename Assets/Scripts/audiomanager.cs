using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public static audiomanager Instance { get; private set; }

    [Header("Audio Source")]
    [SerializeField] AudioSource musicsource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip splash;
    public AudioClip death;
    public AudioClip timer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Debug.LogError("There is two or more AudioManagers");
        }
    }
    private void Start()
    {
        musicsource.clip = background;
        musicsource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.PlayOneShot(clip);
    }


    public void StopSFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Stop();
    }

}
