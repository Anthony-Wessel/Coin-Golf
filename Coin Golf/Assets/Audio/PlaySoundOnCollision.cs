using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    AudioSource src;
    [SerializeField] AudioClip sound;

    private void Start()
    {
        src = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float force = collision.impulse.magnitude / Time.fixedDeltaTime;
        print(force);
        src.PlayOneShot(sound, (force+250)/750);
    }
}
