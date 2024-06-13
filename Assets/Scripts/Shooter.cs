using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileeSpeed=10f;
    [SerializeField] float baseFiringRate = 0.2f;
    [SerializeField] float projectileTimeLife = 5f;
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimunFiringRate = 0.1f;
    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;

    AudioPlayer audioPlayer;

    // Start is called before the first frame update

    private void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, 
                                                transform.position, 
                                                Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileeSpeed;
            }
            Destroy(instance, projectileTimeLife);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, 
                                                        baseFiringRate+firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimunFiringRate, float.MaxValue);                                
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
