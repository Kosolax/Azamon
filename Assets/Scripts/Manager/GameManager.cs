using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using TMPro;

using UnityEngine;

using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<Mission> Missions;

    public Player Player;

    public int CounterDeath;

    private Dictionary<int, Mission> missions;

    public int CurrentMission;

    public Transform PackageSpawningArea;

    public GameObject Barrier;

    public Transform ElevatorTransform;

    public ManagerInteract ManagerInteract;

    public Action ResetLevel;

    public List<string> DeathManagerReaction;

    public TextMeshProUGUI ReactionText;

    public GameObject ReactionPanel;

    [SerializeField]
    private float displayTimer;

    private void Start()
    {
        this.CurrentMission = 1;
        this.missions = this.Missions.ToDictionary(x => x.MissionNumber, x => x);
    }

    public void MissionSuccess(int missionNumber)
    {
        this.CurrentMission++;
        this.Player.NextMission();
        this.EnableBarrier();
        if (this.CurrentMission == 2)
        {
            this.Player.Inventory.HasDoubleJump = true;
        }
    }

    public void MissionLose(int missionNumber)
    {
        this.Player.Death();
        Mission mission = this.missions[missionNumber];
        mission.Reset();
        this.CounterDeath++;
        this.EnableBarrier();
        this.RestartMission();
        StartCoroutine(ManagerReaction(this.Player.RespawnTime));
    }

    public IEnumerator ManagerReaction(float timer)
    {
        yield return new WaitForSeconds(timer);
        int index = Random.Range(0, this.DeathManagerReaction.Count);
        this.ReactionPanel.SetActive(true);
        this.ReactionText.text = this.DeathManagerReaction[index];
        this.ReactionText.text = this.ReactionText.text.Replace("{0}", this.GetCounterDeathFormatted(this.CounterDeath.ToString()));
        yield return new WaitForSeconds(this.displayTimer);
        this.ReactionPanel.SetActive(false);
        this.ReactionText.text = string.Empty;
    }

    private string GetCounterDeathFormatted(string value)
    {
        return value.PadLeft(3, '0');
    }

    public void DisableBarrier()
    {
        this.Barrier.SetActive(false);
    }

    public void EnableBarrier()
    {
        this.Barrier.SetActive(true);
    }

    public void StartMission()
    {
        UIManager.IsMenuOn = false;
        this.missions[this.CurrentMission].SpawnPackage();
        this.ManagerInteract.NeedToClose = true;
        this.ManagerInteract.NeedToOpen = false;
    }

    public void CloseUI()
    {
        UIManager.IsMenuOn = false;
    }

    public void RestartMission()
    {
        this.missions[this.CurrentMission].SpawnPackage();
    }
}
