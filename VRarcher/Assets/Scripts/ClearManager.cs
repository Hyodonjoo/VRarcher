using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject Clear;

    [Header("Main Menu Buttons")]
    public Button MenuButton;
    public Button RestartButton;
    private void OnEnable()
    {
        ScoreManager.OnScoreReached += ShowMenu;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreReached -= ShowMenu;
    }
       
    void ShowMenu()
    {
        Clear.SetActive(true);
        MenuButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }         
}
