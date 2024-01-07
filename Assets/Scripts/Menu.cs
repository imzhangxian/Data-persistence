using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerIdInput;
    // Start is called before the first frame update

    void Awake()
    {
        if (MenuHandler.instance != null)
        {
            playerIdInput.text = MenuHandler.instance.playerId;
        }
        
    }
    public void StartGame()
    {
        LoadScore();
        MenuHandler.instance.playerId = playerIdInput.text;
        SceneManager.LoadScene(MenuHandler.MAIN_SCENE);
    }

    public void Exit()
    {
        SaveScore();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void LoadScore()
    {
        MenuHandler.instance.LoadScore();
    }

    public void SaveScore()
    {
        MenuHandler.instance.SaveScore();
    }
}
