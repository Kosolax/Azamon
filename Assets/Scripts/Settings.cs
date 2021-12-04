using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject Canvas;

    public Rotation Rotation;

    public Slider SensiSlider;

    public Slider VolumeSlider;

    public void CloseSettings()
    {
        this.Canvas.SetActive(false);
        UIManager.IsMenuOn = false;
    }

    public void OnSensiChange(float value)
    {
        this.Rotation.MouseSensitivity = value / 10;
    }

    public void OnVolumeChange(float value)
    {
        AudioListener.volume = value / 100;
    }

    private void Start()
    {
        this.VolumeSlider.onValueChanged.AddListener(OnVolumeChange);
        this.SensiSlider.onValueChanged.AddListener(OnSensiChange);
        AudioListener.volume = 0.6f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this.Canvas.activeSelf)
            {
                this.CloseSettings();
            }
            else if (!UIManager.IsMenuOn && !this.Canvas.activeSelf)
            {
                this.Canvas.SetActive(true);
                UIManager.IsMenuOn = true;
            }
        }
    }
}