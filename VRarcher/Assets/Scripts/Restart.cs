using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Restart : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject Clear;

    [Header("Main Menu Buttons")]
    public Button MenuButton;
    public Button RestartButton;
    void Start()
    {
        RestartButton.onClick.AddListener(OnRestartButtonClick);
    }

    // RestartButton�� ������ �� ȣ��Ǵ� �޼ҵ�
    void OnRestartButtonClick()
    {
        // ������ 0���� �ʱ�ȭ�ϰ� Clear, MenuButton, RestartButton ��Ȱ��ȭ
        ScoreManager.Instance.Reset();
        Clear.SetActive(false);
        MenuButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
    }
}
