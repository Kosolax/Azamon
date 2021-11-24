using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLauncherSewer : MonoBehaviour
{
    public float force;

    public GameManager GameManager;

    public BoxCollider SewerCollider;

    public GameObject Trigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.LaunchTrap();
            this.GameManager.MissionLose(this.GameManager.CurrentMission);
            SewerCollider.enabled = false;
            this.Trigger.SetActive(false);
        }
    }

    void LaunchTrap()
    {
        if (this.GetComponent<Rigidbody>() != null)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.up * force);
        }
    }
}
