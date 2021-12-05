using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLauncherSewer : MonoBehaviour
{
    public float force;

    public GameManager GameManager;

    public BoxCollider SewerCollider;

    public GameObject Trigger;

    public ParticleSystem idleParticleSystem;

    public ParticleSystem launchParticleSystem;

    public AudioSource AudioSource;

    public AudioSource MetalSound;

    private bool isLaunched;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.LaunchTrap();
            this.GameManager.MissionLose();
            SewerCollider.enabled = false;
            this.Trigger.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") && isLaunched)
        {
            this.MetalSound.Play();
        }
    }

    void LaunchTrap()
    {
        if (this.GetComponent<Rigidbody>() != null)
        {
            this.isLaunched = true;
            this.idleParticleSystem.gameObject.SetActive(false);
            this.launchParticleSystem.Play();
            this.AudioSource.Play();
            this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.up * force);
        }
    }
}
