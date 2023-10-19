using UnityEngine;
using UnityEngine.UI;

public class EnhancementGame : MonoBehaviour
{
    public Text enhancementLevelText;
    public Text enhancementChanceText;
    public Text enhancementCostText;
    public Text sellCostText;
    public Text coinsText; // 소지금을 표시할 텍스트
    public Button enhanceButton;
    public Image weaponImage; // 검 이미지를 표시할 UI Image

    public Sprite[] weaponSprites; // 각 강화 단계에 대한 스프라이트 배열

    private int enhancementLevel = 0;
    private float enhancementChance = 100f;
    private float enhancementCost = 500f;
    private int coins = 100000; // 초기 소지금 설정
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
            // 5% 확률로 강화 성공
            if (Random.Range(0f, 100f) <= enhancementChance)
            {
                enhancementLevel++; // 강화 성공하면 단계를 올림
                enhancementChance -= 5f; // 강화 성공 확률을 5% 낮춤
                coins -= (int)enhancementCost; // 강화 비용만큼 소지금 차감
                enhancementCost += 500; // 강화 비용 500원씩 올림
                sellCost = (sellCost +300)*2;
            }
            else
            {
                // 강화 실패 시 확률을 높임 (재시도할수록 확률이 올라감)
                enhancementLevel = 0; // 강화 단계를 0으로 초기화
                enhancementChance = 100f; // 확률을 100으로 초기화
                enhancementCost = 500f; // 강화 비용 500으로 초기화
                coins -= (int)enhancementCost; // 강화 비용만큼 소지금 차감
                sellCost = 0;
            }

            UpdateUI();
            UpdateWeaponImage();
        }
        else
        {
            // 소지금이 부족한 경우에 대한 처리 (예: 메시지 표시)
            Debug.Log("소지금이 부족합니다.");
        }
    }
    public void Sell()
    {
        coins += sellCost; // 판매 가격만큼 소지금 추가
        enhancementLevel = 0; // 강화 단계 초기화
        enhancementChance = 100f; // 강화 확률 초기화
        enhancementCost = 500f; // 강화 비용 초기화
        sellCost = 0; // 판매 가격 초기화

        UpdateUI();
        UpdateWeaponImage();
    }

    void UpdateUI()
    {
        enhancementLevelText.text = "강화 단계: " + enhancementLevel;
        enhancementChanceText.text = "강화 확률: " + enhancementChance.ToString("F1") + "%";
        enhancementCostText.text = "강화 비용: " + enhancementCost;
        coinsText.text = "소지금: " + coins; // 소지금을 업데이트
        sellCostText.text = "판매 비용: " + sellCost;
    }

    void UpdateWeaponImage()
    {
        if (weaponSprites != null && weaponSprites.Length > enhancementLevel)
        {
            // 현재 강화 단계에 해당하는 스프라이트를 설정
            weaponImage.sprite = weaponSprites[enhancementLevel];
        }
    }
    public void EnhanceTo5Level()
    {
        // 5단계로 설정
        enhancementLevel = 5;
        enhancementChance = 75f;
        enhancementCost = 3000f; // 5단계 강화 비용
        sellCost = 18600; // 5단계 판매 가격
        coins -= 20000;

        UpdateUI();
        UpdateWeaponImage();
    }
}