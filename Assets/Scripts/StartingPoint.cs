using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class StartingPoint : MonoBehaviour
{
    public Mission Mission;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null && player.HasPackage)
        {
            this.Mission.IsStarted = true;
        }
    }
}