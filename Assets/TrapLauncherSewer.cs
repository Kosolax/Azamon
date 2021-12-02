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

    void LaunchTrap()
    {
        if (this.GetComponent<Rigidbody>() != null)
        {
            this.idleParticleSystem.gameObject.SetActive(false);
            this.launchParticleSystem.Play();
            this.AudioSource.Play();
            this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.up * force);
        }
    }
}
