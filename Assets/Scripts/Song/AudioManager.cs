using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Song[] allSong = default;
    private AudioSource audioSource;

    private static AudioManager _instance;
    public static AudioManager Instance => _instance;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
    }

    private void OnDestroy()
    {
        if(_instance != null)
        {
            _instance = null;
        }
    }

    public void PlaySongOneShot(string songName)
    {
        for (int i = 0; i < allSong.Length; i++)
        {
            if(allSong[i].audio.name == songName)
            {
                audioSource.PlayOneShot(allSong[i].audio);
                audioSource.volume = allSong[i].volume;

                return;
            }
        }
    }

    public void StopSong(string songName)
    {
        audioSource.Stop();
    }
}
