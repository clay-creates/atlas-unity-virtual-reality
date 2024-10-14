using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsMenuUI : MonoBehaviour
{
    // UI Elements
    public Button mainButton;
    public Button applyButton;
    public Button optionsButton;

    public Toggle gazeHintsToggle;
    public Toggle highContrastToggle;
    public Slider gazeHintVolumeSlider;
    public Slider uiWindowSizeSlider;
    public Slider uiTextSizeSlider;
    public Toggle colorblindModeToggle;
    public TMP_Dropdown colorblindModeDropdown;

    // Settings variables
    private bool gazeHintsEnabled;
    private bool highContrastEnabled;
    private float gazeHintVolume;
    private float uiWindowSize;
    private float uiTextSize;
    private bool colorblindModeEnabled;
    private int colorblindMode; // 0 for normal, 1 for protanopia, 2 for deuteranopia, etc.

    // Start is called before the first frame update
    void Start()
    {
        // Assign button click listeners
        mainButton.onClick.AddListener(LoadMain);
        applyButton.onClick.AddListener(ApplySettings);
        optionsButton.onClick.AddListener(LoadOptions);

        // Assign UI element change listeners
        gazeHintsToggle.onValueChanged.AddListener(OnGazeHintsToggleChanged);
        highContrastToggle.onValueChanged.AddListener(OnHighContrastToggleChanged);
        gazeHintVolumeSlider.onValueChanged.AddListener(OnGazeHintVolumeChanged);
        uiWindowSizeSlider.onValueChanged.AddListener(OnUIWindowSizeChanged);
        uiTextSizeSlider.onValueChanged.AddListener(OnUITextSizeChanged);
        colorblindModeToggle.onValueChanged.AddListener(OnColorblindModeToggleChanged);
        colorblindModeDropdown.onValueChanged.AddListener(OnColorblindModeDropdownChanged);
    }

    // Update is called once per frame
    void Update()
    {
        // 
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("accessibility_main");
    }

    public void ApplySettings()
    {
        // Apply settings based on the current UI values
        gazeHintsEnabled = gazeHintsToggle.isOn;
        highContrastEnabled = highContrastToggle.isOn;
        gazeHintVolume = gazeHintVolumeSlider.value;
        uiWindowSize = uiWindowSizeSlider.value;
        uiTextSize = uiTextSizeSlider.value;
        colorblindModeEnabled = colorblindModeToggle.isOn;
        colorblindMode = colorblindModeDropdown.value;

        // Save these settings to PlayerPrefs or some other persistence system
        PlayerPrefs.SetInt("GazeHintsEnabled", gazeHintsEnabled ? 1 : 0);
        PlayerPrefs.SetInt("HighContrastEnabled", highContrastEnabled ? 1 : 0);
        PlayerPrefs.SetFloat("GazeHintVolume", gazeHintVolume);
        PlayerPrefs.SetFloat("UIWindowSize", uiWindowSize);
        PlayerPrefs.SetFloat("UITextSize", uiTextSize);
        PlayerPrefs.SetInt("ColorblindModeEnabled", colorblindModeEnabled ? 1 : 0);
        PlayerPrefs.SetInt("ColorblindMode", colorblindMode);

        PlayerPrefs.Save();

        // Optionally, you could refresh the settings visually immediately after applying them
        Debug.Log("Settings applied.");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("accessibility_options");
    }

    void OnGazeHintsToggleChanged(bool value)
    {
        gazeHintsEnabled = value;
        Debug.Log("Gaze Hints Enabled: " + value);
    }

    void OnHighContrastToggleChanged(bool value)
    {
        highContrastEnabled = value;
        Debug.Log("High Contrast Enabled: " + value);
    }

    void OnGazeHintVolumeChanged(float value)
    {
        gazeHintVolume = value;
        Debug.Log("Gaze Hint Volume: " + value);
    }

    void OnUIWindowSizeChanged(float value)
    {
        uiWindowSize = value;
        Debug.Log("UI Window Size: " + value);
    }

    void OnUITextSizeChanged(float value)
    {
        uiTextSize = value;
        Debug.Log("UI Text Size: " + value);
    }

    void OnColorblindModeToggleChanged(bool value)
    {
        colorblindModeEnabled = value;
        Debug.Log("Colorblind Mode Enabled: " + value);
    }

    void OnColorblindModeDropdownChanged(int value)
    {
        colorblindMode = value;
        Debug.Log("Colorblind Mode: " + value);
    }
}
