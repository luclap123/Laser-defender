using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool isCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();    
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamge());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            CameraShake();
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax );
        }
    }

    void CameraShake()
    {
        if (cameraShake != null && isCameraShake)
        {
            cameraShake.Play();
        }
    }
}
