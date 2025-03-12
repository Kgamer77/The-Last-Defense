using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{

    public GameObject fadeOut;
    public GameObject loadText;
    public AudioSource buttonClick;

    public GameObject loadButton;
    public int loadInt;


    private void Start()
    {
        loadInt = PlayerPrefs.GetInt("AutoSave");
        if (loadInt > 0)
        {
            loadButton.SetActive(true);
        }
    }

    public void NewGameButton()
    {
        StartCoroutine(NewGameStart());
    }

    IEnumerator NewGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(5);
        loadText.SetActive(true);
        SceneManager.LoadScene(2); //loads to IntroScene(4) scene but for now to Scene1(2)
    }

    public void LoadGameButton() 
    {
        StartCoroutine(LoadGameStart());
    }

    IEnumerator LoadGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(5);
        loadText.SetActive(true);
        SceneManager.LoadScene(loadInt); // loads to previous saved game 
    }

    public void OptionsButton()
    {
        StartCoroutine(OptionStart());
    }

    IEnumerator OptionStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(5);
        loadText.SetActive(true);
        SceneManager.LoadScene(2); // loads to Scene1(2) scene
    }

    public void CreditsButton()
    {
        StartCoroutine(CreditStart());
    }

    IEnumerator CreditStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(5);
        loadText.SetActive(true);
        SceneManager.LoadScene(5); // laods to credits(5) scene
    }
    // Method to handle quitting the game
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #else
            Application.Quit(); // Close the game in the built application
        #endif
    }
    public void LoadSite()
    {
        Application.OpenURL("");
    }
}