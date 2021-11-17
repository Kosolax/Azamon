using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInteract : Interact
{
    public GameObject UI;

    public GameObject EyeDoor;

    private bool needToOpen;

    private bool needToClose;

    public Transform OpenTransform;

    public Transform CloseTransform;

    public override void MakeAction()
    {
        base.MakeAction();
        this.UI.SetActive(true);
        this.needToOpen = true;
    }

    private void Update()
    {
        if (this.needToOpen)
        {
            this.EyeDoor.transform.Translate(this.OpenTransform.transform.position);
        }

        if (this.needToClose)
        {
            this.EyeDoor.transform.Translate(this.CloseTransform.transform.position);
        }
    }
}
