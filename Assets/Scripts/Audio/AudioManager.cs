using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] 
    private AudioSource audioSource;
    public AudioSource AudioSource => audioSource;

    [SerializeField]
    private AudioClip machineGunFireSound;
    public AudioClip MachineGunFireSound => machineGunFireSound;

    [SerializeField]
    private AudioClip rocketFireSound;
    public AudioClip RocketFireSound => rocketFireSound;

    [SerializeField]
    private AudioClip laserFireSound;
    public AudioClip LaserFireSound => laserFireSound;

    [SerializeField]
    private AudioClip towerBuildSound;
    public AudioClip TowerBuildSound => towerBuildSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

   
}
