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

    // RestartButton이 눌렸을 때 호출되는 메소드
    void OnRestartButtonClick()
    {
        // 점수를 0으로 초기화하고 Clear, MenuButton, RestartButton 비활성화
        ScoreManager.Instance.Reset();
        Clear.SetActive(false);
        MenuButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
    }
}
