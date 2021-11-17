using UnityEngine;

public class Interact : MonoBehaviour
{
    public UIManager UIManager;

    public string TextToDisplay;

    private void Start()
    {
        if (this.UIManager == null)
        {
            GameObject uiManagerGameObject = GameObject.Find("UIManager");
            if (uiManagerGameObject != null)
            {
                this.UIManager = uiManagerGameObject.GetComponent<UIManager>();
            }
        }
    }

    public void DisplayText(bool needText)
    {
        if (needText)
        {
            this.UIManager.DisplayInteractionText(this.TextToDisplay);
        }
        else
        {
            this.UIManager.DisplayInteractionText(string.Empty);
        }
    }

    public virtual void MakeAction()
    {

    }
}