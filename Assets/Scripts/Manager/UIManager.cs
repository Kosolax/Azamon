using TMPro;

using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static bool IsMenuOn;

    public TextMeshProUGUI TimerText;

    public TextMeshProUGUI DialogText;

    private void Start()
    {
        IsMenuOn = false;
    }

    public void UpdateTimer(float timer)
    {
        this.TimerText.text = timer.ToString();
    }

    public void DisplayInteractionText(string text)
    {

    }
}