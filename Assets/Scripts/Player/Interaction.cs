using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float Range;

    public Interact Interact;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, this.Range, 0))
        {
            this.Interact = hit.transform.gameObject.GetComponent<Interact>();
            this.Interact.DisplayText();
        }
        else
        {
            this.Interact = null;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            this.Interact.MakeAction();
        }
    }
}
