using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject Title;
    public GameObject mainMenu;
    public GameObject options;
    public GameObject about;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button optionButton;
    public Button aboutButton;
    public Button quitButton;

    public List<Button> returnButtons;

    private CanvasGroup mainMenuCanvasGroup;    

    // Start is called before the first frame update
    void Start()
    {
        mainMenuCanvasGroup = mainMenu.GetComponent<CanvasGroup>();        
        if (mainMenuCanvasGroup == null)
        {
            mainMenuCanvasGroup = mainMenu.AddComponent<CanvasGroup>();
        }

        EnableMainMenu();

        // Hook events
        startButton.onClick.AddListener(() => StartCoroutine(FadeOutAndStartGame()));
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator FadeOutAndStartGame()
    {
        float duration = 5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            mainMenuCanvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / duration);            
            yield return null;
        }

        mainMenuCanvasGroup.alpha = 0;
        HideAll();        
    }

    public void StartGame()
    {
        HideAll();
        //SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void HideAll()
    {
        Title.SetActive(false);
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
    }
    public void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
    }
    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
    }
}
