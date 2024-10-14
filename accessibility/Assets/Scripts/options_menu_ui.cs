using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OptionsMenuUI : MonoBehaviour
{
    // Button references
    public Button mainButton;
    public Button applyButton;
    public Button settingsButton;

    // UI element references
    public Toggle vignetteToggle;
    public TMP_Dropdown rotationTypeDropdown;
    public TMP_Dropdown locomotionTypeDropdown;

    // Settings variables
    private bool vignetteEnabled;
    private int rotationType;  // 0 for smooth, 1 for snap
    private int locomotionType; // 0 for teleport, 1 for smooth locomotion

    // Start is called before the first frame update
    void Start()
    {
        // Assign button click listeners
        mainButton.onClick.AddListener(LoadMain);
        applyButton.onClick.AddListener(ApplyOptions);
        settingsButton.onClick.AddListener(LoadSettings);

        // Assign UI element listeners
        vignetteToggle.onValueChanged.AddListener(OnVignetteToggleChanged);
        rotationTypeDropdown.onValueChanged.AddListener(OnRotationTypeChanged);
        locomotionTypeDropdown.onValueChanged.AddListener(OnLocomotionTypeChanged);

        // Initialize values (e.g., from PlayerPrefs or default settings)
        LoadSavedSettings();
    }

    // Load the main menu scene
    public void LoadMain()
    {
        SceneManager.LoadScene("main_menu");
    }

    // Apply the selected options
    public void ApplyOptions()
    {
        // Apply the current settings
        vignetteEnabled = vignetteToggle.isOn;
        rotationType = rotationTypeDropdown.value; // 0 for smooth, 1 for snap
        locomotionType = locomotionTypeDropdown.value; // 0 for teleport, 1 for smooth

        // Save these settings to PlayerPrefs or another system
        PlayerPrefs.SetInt("VignetteEnabled", vignetteEnabled ? 1 : 0);
        PlayerPrefs.SetInt("RotationType", rotationType);
        PlayerPrefs.SetInt("LocomotionType", locomotionType);
        PlayerPrefs.Save();

        Debug.Log("Options Applied");
    }

    // Load the settings scene
    public void LoadSettings()
    {
        SceneManager.LoadScene("accessibilty_settings");
    }

    // Handle Vignette Toggle Change
    private void OnVignetteToggleChanged(bool isOn)
    {
        vignetteEnabled = isOn;
        Debug.Log("Vignette Toggled: " + isOn);
    }

    // Handle Rotation Type Dropdown Change
    private void OnRotationTypeChanged(int index)
    {
        rotationType = index;
        Debug.Log("Rotation Type Changed: " + (rotationType == 0 ? "Smooth" : "Snap"));
    }

    // Handle Locomotion Type Dropdown Change
    private void OnLocomotionTypeChanged(int index)
    {
        locomotionType = index;
        Debug.Log("Locomotion Type Changed: " + (locomotionType == 0 ? "Teleport" : "Smooth"));
    }

    // Load previously saved settings or set defaults
    private void LoadSavedSettings()
    {
        // Load the saved settings or set default values
        vignetteEnabled = PlayerPrefs.GetInt("VignetteEnabled", 1) == 1; // Default: enabled
        rotationType = PlayerPrefs.GetInt("RotationType", 0); // Default: smooth
        locomotionType = PlayerPrefs.GetInt("LocomotionType", 0); // Default: teleport

        // Update UI elements to reflect loaded settings
        vignetteToggle.isOn = vignetteEnabled;
        rotationTypeDropdown.value = rotationType;
        locomotionTypeDropdown.value = locomotionType;
    }
}
