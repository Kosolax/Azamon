using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TrapDeath : MonoBehaviour
{
    private GameManager GameManager;

    private void Awake()
    {
        if (this.GameManager == null)
        {
            this.GameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GameManager.MissionLose();
            this.gameObject.SetActive(false);
        }
    }
}