using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static bool GameIsPause = false;
    public GameObject menu;
    public GameObject ResumeButton;


    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
    
        
   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                text.text = ("Paused");
                Pause(); 
            }
           
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        menu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        Cursor.visible = true;
        menu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Resume();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OutofLives()
    {
        text.text = ("You are out of lives!");
        ResumeButton.SetActive(false);
        Pause();
    }

    public void GameBeat()
    {
        PlayerPrefs.DeleteAll();
        text.text = ("You beat the game!");
        ResumeButton.SetActive(false);
        Pause();
    }

    public void OutOfGas()
    {
        text.text = ("You are out of Gas");
        ResumeButton.SetActive(false);
        Pause();
    }
}