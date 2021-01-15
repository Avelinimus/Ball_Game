using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static int level = 1;
    public Text LevelText;
    public GameObject Menu;
    public Text TextStartGame;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        WriteLevel();
    }

    void WriteLevel() 
    {
        LevelText.text = "Level is " + level;
    }

    public void Pause() 
    {
        if (Menu.active)
        {
            Menu.SetActive(false);
            TextStartGame.text = "Continue game";
            Time.timeScale = 1;
        }
        else 
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Exit() 
    {
        Application.Quit();
    }

    public void Start_Cont_Game() 
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
        TextStartGame.text = "Continue game";
    }
}
