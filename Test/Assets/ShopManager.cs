using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel; // 상점 패널
    public GameObject enhancementPanel; // 강화하기 패널

    void Start()
    {
        // 처음에는 상점 패널 활성화, 강화하기 패널 비활성화
        shopPanel.SetActive(false);
        enhancementPanel.SetActive(true);
    }

    public void BackButtonPressed()
    {
        // 상점 패널을 비활성화
        shopPanel.SetActive(false);

        // 강화하기 패널을 활성화
        enhancementPanel.SetActive(true);
    }
    public void StoreButtonPressed()
    {
        // 강화하기 패널을 비활성화
        enhancementPanel.SetActive(false);

        // 상점 패널을 활성화
        shopPanel.SetActive(true);
    }
}