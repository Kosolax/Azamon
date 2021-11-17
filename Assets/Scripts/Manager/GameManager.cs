using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

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

    private void Start()
    {
        this.CurrentMission = 1;
        this.missions = this.Missions.ToDictionary(x => x.MissionNumber, x => x);
    }

    public void MissionSuccess(int missionNumber)
    {
        this.CurrentMission = missionNumber++;
        this.Player.NextMission();
        this.EnableBarrier();
    }

    public void MissionLose(int missionNumber)
    {
        this.Player.Death();
        Mission mission = this.missions[missionNumber];
        mission.Reset();
        this.CounterDeath++;
        this.EnableBarrier();
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
}
