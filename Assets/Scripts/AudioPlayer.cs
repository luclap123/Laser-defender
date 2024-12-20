using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootAudio;
    [SerializeField] [Range(0f, 1f)] float shootVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageAudio;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;
    static AudioPlayer instance;
    private void Awake() {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        // int instanceCount = FindObjectsOfType(GetType()).Length;
        // if (instanceCount >1)
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootAudio, shootVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageAudio, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, camPos, volume);
        }
    }
}
