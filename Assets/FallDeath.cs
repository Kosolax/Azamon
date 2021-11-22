using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public Player Player;

    public float fallDistance;

    private void Update()
    {
        if (this.Player.Movement.isGrounded)
        {
            this.transform.position = new Vector3(this.Player.transform.position.x, this.Player.transform.position.y - fallDistance, this.Player.transform.position.z);
        }
    }
}
