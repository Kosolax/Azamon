using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image DoubleJumpImage;

    public Image PackageImage;

    public Sprite DisabledDoubleJumpSprite;

    public Sprite EnabledDoubleJumpSprite;

    public bool hasDoubleJump;

    public Sprite Sprite;

    private bool hasPackage;

    private bool hasUsedDoubleJump;

    public bool HasDoubleJump
    {
        get
        {
            return hasDoubleJump;
        }
        set
        {
            this.hasDoubleJump = value;
            this.DoubleJumpImage.gameObject.SetActive(this.hasDoubleJump);
        }
    }

    public bool HasPackage
    {
        get
        {
            return hasPackage;
        }
        set
        {
            this.hasPackage = value;
            this.PackageImage.sprite = this.Sprite;
            this.PackageImage.gameObject.SetActive(this.hasPackage);
        }
    }

    public bool HasUsedDoubleJump
    {
        get
        {
            return hasUsedDoubleJump;
        }
        set
        {
            this.hasUsedDoubleJump = value;
            this.DoubleJumpImage.sprite = this.hasUsedDoubleJump ? this.DisabledDoubleJumpSprite : this.EnabledDoubleJumpSprite;
        }
    }
}