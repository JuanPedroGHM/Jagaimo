using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> AudioClips;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }



    public void PlaySound(string clipName)
    {
        Debug.Log("Try to play sound: " + clipName );
        var clip = AudioClips.First(t => t.name == clipName);
        if (clip == null) return;
        _audioSource.PlayOneShot(clip);
    }

}
