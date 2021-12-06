using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BoneBreak : MonoBehaviour
{
    public AudioSource AudioSource;

    private void Start()
    {
        this.AudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") && this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 2)
        {
            this.AudioSource.Play();
        }
    }
}
