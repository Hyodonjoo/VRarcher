using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveToMenu : MonoBehaviour
{
    public Button MenuButton;

    void Start()
    {
        MenuButton.onClick.AddListener(OnMenuButtonClick);
    }

    void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Scene_Practice_Map");
    }
}
