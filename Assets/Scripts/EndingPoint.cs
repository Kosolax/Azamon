using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EndingPoint : MonoBehaviour
{
    public Mission Mission;

    public GameManager GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (this.GameManager.CurrentMission == this.Mission.MissionNumber)
        {
            Player player = other.GetComponent<Player>();
            if (player != null && player.HasPackage)
            {
                this.Mission.IsDone = true;
            }
        }
    }
}
