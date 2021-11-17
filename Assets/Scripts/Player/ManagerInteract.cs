using UnityEngine;

public class ManagerInteract : Interact
{
    public GameObject UI;

    public GameObject EyeDoor;

    public bool NeedToOpen;

    public bool NeedToClose;

    public Transform OpenTransform;

    public Transform CloseTransform;

    public override void MakeAction()
    {
        base.MakeAction();
        this.UI.SetActive(true);
        this.NeedToOpen = true;
        this.UIManager.DisplayInteractionText(string.Empty);
        UIManager.IsMenuOn = true;
    }

    private void Update()
    {
        if (this.NeedToOpen)
        {
            this.EyeDoor.transform.Translate(this.OpenTransform.transform.position);
        }

        if (this.NeedToClose)
        {
            this.EyeDoor.transform.Translate(this.CloseTransform.transform.position);
        }
    }
}
