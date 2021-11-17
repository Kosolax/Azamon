using UnityEngine;

public class Interact : MonoBehaviour
{
    public UIManager UIManager;

    public string TextToDisplay;

    public void DisplayText()
    {
        this.UIManager.DisplayInteractionText(this.TextToDisplay);
    }

    public virtual void MakeAction()
    {

    }
}