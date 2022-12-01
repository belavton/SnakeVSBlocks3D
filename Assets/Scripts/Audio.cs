using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip AudioClip;
    public AudioClip AudioClip2;
    public AudioClip Background;
    [Min(0)]
    public float Volume;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        _audio.Play();
    }

    public void TakeFoodAudio()
    {
        _audio.PlayOneShot(AudioClip, Volume);
    }

    public void DestroyBlock()
    {
        _audio.PlayOneShot(AudioClip2);
    }

    private void OnEnable()
    {
        _audio.PlayOneShot(Background);
    }

    private void OnDisable()
    {
        _audio.Stop();
    }
}
