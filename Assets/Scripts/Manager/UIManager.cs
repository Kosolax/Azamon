using TMPro;

using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static bool IsMenuOn { get; set; }

    public TextMeshProUGUI TimerText;

    public TextMeshProUGUI InteractText;

    private void Update()
    {
        if (IsMenuOn)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void UpdateTimer(string timer)
    {
        this.TimerText.text = timer;
    }

    public void DisplayInteractionText(string text)
    {
        this.InteractText.text = text;
    }
}