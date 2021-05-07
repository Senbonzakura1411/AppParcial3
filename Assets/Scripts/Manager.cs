using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    private string username;
    private string password;
    private string email;
    private string country, state, city;
    private string about;

    public GameObject loginPanel, mainMenuPanel, userInfoPanel, userAddressPanel, userAboutPanel, errorPanel;

    public TMP_InputField loginNameField, loginPassField;

    public TMP_InputField userNameField, passField, emailField, countryField, stateField, cityField, aboutField;

    public Button loginButton, goToRegister, registerButton;

    public AudioSource audioSource;

    Dictionary<string, User> users = new Dictionary<string, User>()
    {
        {"default", new User ("default", "default", "default", "default", "default", "default") }
    };

    void Start()
    {
        loginButton.onClick.AddListener(UserLogin);
        goToRegister.onClick.AddListener(GoToRegistration);
        registerButton.onClick.AddListener(UserRegistration);
    }

    void UserLogin()
    {
        username = loginNameField.text;
        password = loginPassField.text;

        User foundUser;

        if (users.TryGetValue(username, out foundUser) && foundUser.password == password)
        {
            ErrorMessage("User Authenticated. Logged in.");
            loginPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
        else
        {
            ErrorMessage("Invalid data. Please, try again.");
        }
    }

    void GoToRegistration()
    {
        loginPanel.SetActive(false);
        userInfoPanel.SetActive(true);
    }
    void UserRegistration()
    {
        about = aboutField.text;

        users.Add(username, new User(password, email, country, state, city, about));
        loginPanel.SetActive(true);
        userAboutPanel.SetActive(false);
    }
    void ErrorMessage(string message)
    {
        errorPanel.GetComponentInChildren<TextMeshProUGUI>().text = message;
        errorPanel.SetActive(true);
    }

    public void GoToUserAddress()
    {
        username = userNameField.text;
        password = passField.text;
        email = emailField.text;

        if (users.ContainsKey(username))
        {
            ErrorMessage("Username already exists. Please, pick another one.");
        }
        else if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
        {
            ErrorMessage("Data input is missing or incorrect. Please, try again.");
        }
        else
        {
            userInfoPanel.SetActive(false);
            userAddressPanel.SetActive(true);
        }
    }
    public void GoToUserAbout()
    {
        country = countryField.text;
        state = stateField.text;
        city = cityField.text;

        if (string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(state) || string.IsNullOrWhiteSpace(city))
        {
            ErrorMessage("Data input is missing or incorrect. Please, try again.");
        }
        else
        {
            userAddressPanel.SetActive(false);
            userAboutPanel.SetActive(true);
        }
    }

    public void GoBackToAddress()
    {
        userAboutPanel.SetActive(false);
        userAddressPanel.SetActive(true);
    }

    public void GoToLogin()
    {
        userInfoPanel.SetActive(false);
        loginPanel.SetActive(true);
    }
    public void GoToUserInfo()
    {
        userInfoPanel.SetActive(true);
        userAddressPanel.SetActive(false);
    }
    public void OnPlayClick()
    {
        audioSource.Play();
    }

    public void OnLogoutClick()
    {
        loginPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        audioSource.Stop();
    }

    public void OnOkClick()
    {
        errorPanel.SetActive(false);
    }
}
