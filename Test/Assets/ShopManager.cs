using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel; // ���� �г�
    public GameObject enhancementPanel; // ��ȭ�ϱ� �г�

    void Start()
    {
        // ó������ ���� �г� Ȱ��ȭ, ��ȭ�ϱ� �г� ��Ȱ��ȭ
        shopPanel.SetActive(false);
        enhancementPanel.SetActive(true);
    }

    public void BackButtonPressed()
    {
        // ���� �г��� ��Ȱ��ȭ
        shopPanel.SetActive(false);

        // ��ȭ�ϱ� �г��� Ȱ��ȭ
        enhancementPanel.SetActive(true);
    }
    public void StoreButtonPressed()
    {
        // ��ȭ�ϱ� �г��� ��Ȱ��ȭ
        enhancementPanel.SetActive(false);

        // ���� �г��� Ȱ��ȭ
        shopPanel.SetActive(true);
    }
}