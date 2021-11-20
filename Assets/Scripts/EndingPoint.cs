using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EndingPoint : MonoBehaviour
{
    public Mission Mission;

    public GameManager GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (this.GameManager.CurrentMission == this.Mission.MissionNumber && this.Mission.IsStarted)
        {
            Player player = other.GetComponent<Player>();
            if (player != null && player.Inventory.HasPackage)
            {
                this.Mission.IsDone = true;
            }
        }
    }
}
