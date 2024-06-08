using UnityEngine;

public class UI_off : MonoBehaviour
{
    public GameObject PlayUI;
    public GameObject ScoreManager;
    void Start()
    {
        PlayUI.SetActive(false);
        ScoreManager.SetActive(false);
    }
}
