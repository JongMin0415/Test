using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Text enhancementLevelText;
    public Image weaponImage; // Reference to your weapon's image component
    public Sprite[] weaponSprites; // Reference to your weapon's upgrade sprites

    private int enhancementLevel = 0;

    void Start()
    {
        UpdateUI();
    }

    public void UpgradeToLevel5()
    {
        if (enhancementLevel < 5)
        {
            enhancementLevel = 5; // Set the enhancement level to 5

            // Update the UI and weapon image
            UpdateUI();
            UpdateWeaponImage();
        }
    }

    void UpdateUI()
    {
        enhancementLevelText.text = "강화 단계: " + enhancementLevel;
    }

    void UpdateWeaponImage()
    {
        if (weaponSprites != null && weaponSprites.Length > enhancementLevel)
        {
            // Set the weapon's image to the corresponding upgrade sprite
            weaponImage.sprite = weaponSprites[enhancementLevel];
        }
    }
}