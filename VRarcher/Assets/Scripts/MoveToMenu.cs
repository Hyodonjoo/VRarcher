using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveToMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject Clear;

    [Header("Main Menu Buttons")]
    public Button MenuButton;
    public Button RestartButton;

    void Start()
    {
        MenuButton.onClick.AddListener(OnMenuButtonClick);
    }

    void OnMenuButtonClick()
    {
        ScoreManager.Instance.Reset();
        Clear.SetActive(false);
        MenuButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        SceneManager.LoadScene("map_waitroom");
    }
}
