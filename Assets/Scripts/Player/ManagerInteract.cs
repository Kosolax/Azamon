using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class ManagerInteract : Interact
{
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject RandomInteraction;

    public GameObject EyeDoor;

    public bool NeedToOpen;

    public bool NeedToClose;

    public Transform OpenTransform;

    public Transform CloseTransform;

    public bool HasReadLevel1;
    public bool HasReadLevel2;
    public bool HasReadLevel3;

    public GameManager GameManager;

    public List<string> RandomManagerInteraction;

    public bool ShouldDisplay()
    {
        switch(this.GameManager.CurrentMission)
        {
            case 1:
                return !this.HasReadLevel1;
            case 2:
                return !this.HasReadLevel2;
            case 3:
                return !this.HasReadLevel3;
        }

        return false;
    }

    public override void MakeAction()
    {
        base.MakeAction();

        if (!this.HasReadLevel1 && !this.HasReadLevel2 && !this.HasReadLevel3 && this.ShouldDisplay())
        {
            // level 1
            this.UI1.SetActive(true);
            this.NeedToOpen = true;
            this.UIManager.DisplayInteractionText(string.Empty);
            UIManager.IsMenuOn = true;
            this.HasReadLevel1 = true;
        }
        else if (this.HasReadLevel1 && !this.HasReadLevel2 && !this.HasReadLevel3 && this.ShouldDisplay())
        {
            // level 2
            this.UI2.SetActive(true);
            this.NeedToOpen = true;
            this.UIManager.DisplayInteractionText(string.Empty);
            UIManager.IsMenuOn = true;
            this.HasReadLevel2 = true;
        }
        else if (this.HasReadLevel1 && this.HasReadLevel2 && !this.HasReadLevel3 && this.ShouldDisplay())
        {
            // level 3
            this.UI3.SetActive(true);
            this.NeedToOpen = true;
            this.UIManager.DisplayInteractionText(string.Empty);
            UIManager.IsMenuOn = true;
            this.HasReadLevel3 = true;
        }
        else
        {
            this.RandomInteraction.SetActive(true);
            this.NeedToOpen = true;
            this.UIManager.DisplayInteractionText(string.Empty);
            UIManager.IsMenuOn = true;
            int index = Random.Range(0, this.RandomManagerInteraction.Count);
            this.RandomInteraction.GetComponentInChildren<TextMeshProUGUI>().text = this.RandomManagerInteraction[index];
        }
    }

    private void Update()
    {
        if (this.NeedToOpen)
        {
            this.EyeDoor.transform.position = this.OpenTransform.transform.position;
        }

        if (this.NeedToClose)
        {
            this.EyeDoor.transform.position = this.CloseTransform.transform.position;
        }
    }
}
