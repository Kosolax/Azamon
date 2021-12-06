using UnityEngine;
using UnityEngine.UI;

public class PackageInteract : Interact
{
    public Player Player;
    public GameObject Barrier;
    public Sprite Sprite;
    public Inventory Inventory;

    public override void MakeAction()
    {
        base.MakeAction();
        this.Player.Inventory.HasPackage = true;
        Destroy(this.gameObject);
        this.Barrier.SetActive(false);
        this.UIManager.DisplayInteractionText(string.Empty);
    }

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

        if (this.Player == null)
        {
            GameObject playerGameObject = GameObject.Find("Player");
            if (playerGameObject != null)
            {
                this.Player = playerGameObject.GetComponent<Player>();
                this.Inventory = playerGameObject.GetComponent<Inventory>();
                this.Inventory.Sprite = this.Sprite;
            }
        }

        if (this.Barrier == null)
        {
            this.Barrier = GameObject.Find("MurTransparent");
        }
    }
}
