using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameManager GameManager;

    public bool IsDone;

    public bool IsStarted;

    public float MaxTime;

    public int MissionNumber;

    public GameObject Package;

    public float Timer;

    public UIManager UIManager;

    private bool hasCallSuccess;

    public void Reset()
    {
        this.Timer = this.MaxTime;
        this.IsDone = false;
        this.IsStarted = false;
        this.hasCallSuccess = false;
    }

    public void SpawnPackage()
    {
        GameObject packageInstantiated = Instantiate(this.Package, this.GameManager.PackageSpawningArea);
        packageInstantiated.transform.localPosition = new Vector3(0, 0, 0);
        packageInstantiated.transform.localRotation = Quaternion.identity;
    }

    private void Start()
    {
        this.Reset();
    }

    private void Update()
    {
        if (this.IsStarted && !this.IsDone)
        {
            this.Timer -= Time.deltaTime;
            this.UIManager.UpdateTimer(this.Timer.ToString());
            if (this.Timer <= 0f)
            {
                this.GameManager.MissionLose(this.MissionNumber);
                this.UIManager.UpdateTimer(string.Empty);
            }
        }

        if (this.IsDone && !this.hasCallSuccess)
        {
            this.hasCallSuccess = true;
            Debug.Log("hehe");
            this.GameManager.MissionSuccess(this.MissionNumber);
            this.UIManager.UpdateTimer(string.Empty);
        }
    }
}