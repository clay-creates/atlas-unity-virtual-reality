using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main_menu_ui : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button settingsButton;
    public Button optionsButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        settingsButton.onClick.AddListener(LoadSettings);
        optionsButton.onClick.AddListener(LoadOptions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Starting Game");
        //SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("accessibilty_settings");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("accessibilty_options");
    }
}
