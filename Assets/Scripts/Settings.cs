using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject Canvas;
    public Slider VolumeSlider;
    public Slider SensiSlider;
    public Rotation Rotation;

    private void Start()
    {
        this.VolumeSlider.onValueChanged.AddListener(OnVolumeChange);
        this.SensiSlider.onValueChanged.AddListener(OnSensiChange);
        AudioListener.volume = 0.6f;
    }

    public void OnVolumeChange(float value)
    {
        Debug.Log(value);
        AudioListener.volume = value / 100;
    }

    public void OnSensiChange(float value)
    {
        this.Rotation.MouseSensitivity = value / 10;
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

    public void CloseSettings()
    {
        this.Canvas.SetActive(false);
        UIManager.IsMenuOn = false;
    }
}