using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDeath : MonoBehaviour
{
    public GameManager GameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GameManager.MissionLose(this.GameManager.CurrentMission);
        }
    }
}
