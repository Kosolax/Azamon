using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float Range;

    public ManagerInteract ManagerInteract;
    public PackageInteract PackageInteract;

    private void Update()
    {
        if (UIManager.IsMenuOn) return;

        if (ManagerInteract != null)
        {
            this.ManagerInteract.DisplayText(false);
        }
        if (PackageInteract != null)
        {
            this.PackageInteract.DisplayText(false);
        }

        if (Physics.Raycast(transform.position + transform.forward * 0.6f, transform.TransformDirection(Vector3.forward), out RaycastHit hit, this.Range))
        {
            this.ManagerInteract = hit.transform.gameObject.GetComponent<ManagerInteract>();

            if (this.ManagerInteract != null)
            {
                this.ManagerInteract.DisplayText(true);
            }
            else
            {
                this.PackageInteract = hit.transform.gameObject.GetComponent<PackageInteract>();

                if (this.PackageInteract != null)
                {
                    this.PackageInteract.DisplayText(true);
                }
            }
        }
        else
        {
            this.PackageInteract = null;
            this.ManagerInteract = null;
        }

        if (Input.GetKeyDown(KeyCode.F) && this.ManagerInteract != null)
        {
            this.ManagerInteract.MakeAction();
        }

        if (Input.GetKeyDown(KeyCode.F) && this.PackageInteract != null)
        {
            this.PackageInteract.MakeAction();
        }
    }
}
