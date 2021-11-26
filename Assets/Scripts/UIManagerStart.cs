using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerStart : MonoBehaviour
{
    public List<GameObject> ThingsToEnable;

    public List<GameObject> ThingsToDisable;

    public void Play()
    {
        UIManager.IsMenuOn = false;
        foreach (var item in this.ThingsToEnable)
        {
            item.SetActive(true);
        }

        foreach (var item in this.ThingsToDisable)
        {
            item.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        UIManager.IsMenuOn = true;
    }
}
