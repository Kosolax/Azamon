using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class StartingPoint : MonoBehaviour
{
    public GameManager GameManager;

    public Mission Mission;

    private void OnTriggerEnter(Collider other)
    {
        if (this.GameManager.CurrentMission == this.Mission.MissionNumber)
        {
            Player player = other.GetComponent<Player>();
            if (player != null && player.Inventory.HasPackage)
            {
                this.Mission.IsStarted = true;
            }
        }
    }
}