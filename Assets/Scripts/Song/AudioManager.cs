using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Song[] allSong = default;
    private AudioSource audioSource;

    private void PlaySong(string songName)
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
}
