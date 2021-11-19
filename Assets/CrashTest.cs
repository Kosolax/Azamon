using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashTest : MonoBehaviour
{
    public bool setActive;

    public float force;

    public BoxCollider TrapCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.setActive == true)
        {
            this.LaunchTrap();
        }
    }

    void LaunchTrap()
    {
        this.setActive = false;
        this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.LaunchTrap();
            other.GetComponent<Player>().Death();
        }
    }
}