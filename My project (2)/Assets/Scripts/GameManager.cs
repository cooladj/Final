using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public GameObject PauseGameOverMenuGameObject;
    private Menu menu;
    [SerializeField] private AudioManger audioManger;

    private void Start()
    {
        
    }

    private void Awake()
    {

        Cursor.visible=false;
        menu = PauseGameOverMenuGameObject.GetComponent<Menu>();
    }

   

    // Start is called before the first frame update

   

    // Update is called once per frame
   

    public void OnDeath(int Lives)
    {
        Save(Lives);
        Time.timeScale = 0f;
        StartCoroutine(DelayScenceLoad());



    }

    IEnumerator DelayScenceLoad()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameBeat()
    {
        // Debug.Log("You beat the Game");
        menu.GameBeat();
    }

    public void OutOfLives()
    {
        audioManger.Play("Lose");
        menu.OutofLives();
        
    }

    public void outofGas()
    {
        audioManger.Play("Lose");
        menu.OutOfGas();
    }

    public void Save(int Lives)
    {
        PlayerPrefs.SetInt("LivesLeft" ,Lives);
    }



    
   
   
}
    