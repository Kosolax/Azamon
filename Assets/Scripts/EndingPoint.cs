using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EndingPoint : MonoBehaviour
{
    public Mission Mission;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null && player.HasPackage)
        {
            this.Mission.IsDone = true;
        }
    }
}
