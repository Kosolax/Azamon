using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLauncher : MonoBehaviour
{
    public bool setActive;

    public float force;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && this.setActive == false)
        {
            this.LaunchTrap();
        }
    }

    void LaunchTrap()
    {
        this.setActive = true;
        if (this.GetComponent<Rigidbody>() != null)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * force);
        }
    }
}
