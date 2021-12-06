using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]

public class SoundOnCollision : MonoBehaviour
{
    public AudioSource AudioSource;

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.Play();
    }
}
