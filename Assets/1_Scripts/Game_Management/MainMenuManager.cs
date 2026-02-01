using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    
    [Header("References"), Space(5)]
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitGameButton;
    [SerializeField] private GameObject _fadedImages;
    [Space(5)]
    [SerializeField] private bool _allowInteractionWhisButtons;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void StartGame()
    {
        if (_allowInteractionWhisButtons)
        {
            print("StartGame");
            StartCoroutine(LoadScene());
        }
    }

    public void Credits()
    {
        if (_allowInteractionWhisButtons)
        {
            print("Credits");
        }
    }

    public void ExitGame()
    {
        if (_allowInteractionWhisButtons)
        {
            print("ExitGame");
            Application.Quit();
        }
    }

    public void Allow_Interaction_Whis_Buttons()
    {
        _fadedImages.SetActive(false);
        _allowInteractionWhisButtons = true;
    }
    
    public IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Lvl_Church");

        while (!asyncLoad.isDone)
        {
            // Afficher un loader ou une barre de progression
            yield return null;
        }
    }
}
