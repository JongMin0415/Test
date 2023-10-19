using UnityEngine;
using UnityEngine.UI;

public class EnhancementGame : MonoBehaviour
{
    public Text enhancementLevelText;
    public Text enhancementChanceText;
    public Text enhancementCostText;
    public Text sellCostText;
    public Text coinsText; // �������� ǥ���� �ؽ�Ʈ
    public Button enhanceButton;
    public Image weaponImage; // �� �̹����� ǥ���� UI Image

    public Sprite[] weaponSprites; // �� ��ȭ �ܰ迡 ���� ��������Ʈ �迭

    private int enhancementLevel = 0;
    private float enhancementChance = 100f;
    private float enhancementCost = 500f;
    private int coins = 100000; // �ʱ� ������ ����
    private int sellCost = 0;

    void Start()
    {
        UpdateUI();
        UpdateWeaponImage();
    }

    public void Enhance()
    {
        if (coins >= enhancementCost)
        {
            // 5% Ȯ���� ��ȭ ����
            if (Random.Range(0f, 100f) <= enhancementChance)
            {
                enhancementLevel++; // ��ȭ �����ϸ� �ܰ踦 �ø�
                enhancementChance -= 5f; // ��ȭ ���� Ȯ���� 5% ����
                coins -= (int)enhancementCost; // ��ȭ ��븸ŭ ������ ����
                enhancementCost += 500; // ��ȭ ��� 500���� �ø�
                sellCost = (sellCost +300)*2;
            }
            else
            {
                // ��ȭ ���� �� Ȯ���� ���� (��õ��Ҽ��� Ȯ���� �ö�)
                enhancementLevel = 0; // ��ȭ �ܰ踦 0���� �ʱ�ȭ
                enhancementChance = 100f; // Ȯ���� 100���� �ʱ�ȭ
                enhancementCost = 500f; // ��ȭ ��� 500���� �ʱ�ȭ
                coins -= (int)enhancementCost; // ��ȭ ��븸ŭ ������ ����
                sellCost = 0;
            }

            UpdateUI();
            UpdateWeaponImage();
        }
        else
        {
            // �������� ������ ��쿡 ���� ó�� (��: �޽��� ǥ��)
            Debug.Log("�������� �����մϴ�.");
        }
    }
    public void Sell()
    {
        coins += sellCost; // �Ǹ� ���ݸ�ŭ ������ �߰�
        enhancementLevel = 0; // ��ȭ �ܰ� �ʱ�ȭ
        enhancementChance = 100f; // ��ȭ Ȯ�� �ʱ�ȭ
        enhancementCost = 500f; // ��ȭ ��� �ʱ�ȭ
        sellCost = 0; // �Ǹ� ���� �ʱ�ȭ

        UpdateUI();
        UpdateWeaponImage();
    }

    void UpdateUI()
    {
        enhancementLevelText.text = "��ȭ �ܰ�: " + enhancementLevel;
        enhancementChanceText.text = "��ȭ Ȯ��: " + enhancementChance.ToString("F1") + "%";
        enhancementCostText.text = "��ȭ ���: " + enhancementCost;
        coinsText.text = "������: " + coins; // �������� ������Ʈ
        sellCostText.text = "�Ǹ� ���: " + sellCost;
    }

    void UpdateWeaponImage()
    {
        if (weaponSprites != null && weaponSprites.Length > enhancementLevel)
        {
            // ���� ��ȭ �ܰ迡 �ش��ϴ� ��������Ʈ�� ����
            weaponImage.sprite = weaponSprites[enhancementLevel];
        }
    }
    public void EnhanceTo5Level()
    {
        // 5�ܰ�� ����
        enhancementLevel = 5;
        enhancementChance = 75f;
        enhancementCost = 3000f; // 5�ܰ� ��ȭ ���
        sellCost = 18600; // 5�ܰ� �Ǹ� ����
        coins -= 20000;

        UpdateUI();
        UpdateWeaponImage();
    }
}