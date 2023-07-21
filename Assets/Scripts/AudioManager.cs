using Cinemachine.PostFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;

    public const string MUSIC_KEY = "music_Volume";
    public const string SFX_KEY = "sfx_Volume";
    public const string MASTER_KEY = "master_Volume";

    private void Awake()
    {
         if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadVolume();
    }

    void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1.0f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1.0f);
        float masterVolume = PlayerPrefs.GetFloat(MASTER_KEY, 1.0f);

        mixer.SetFloat(Audio.MUSIC_MIXER, Mathf.Log10(musicVolume) * 20); 
        mixer.SetFloat(Audio.SFX_MIXER, Mathf.Log10(sfxVolume) * 20); 
        mixer.SetFloat(Audio.MASTER_MIXER, Mathf.Log10(masterVolume) * 20); 
    }
}
