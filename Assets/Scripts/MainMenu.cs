using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MainMenu : MonoBehaviour
{
    public TMP_InputField playerName;
    public TMP_Text topScore;
    
    void Awake()
    {
        BestScore();
    }
    
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        GetPlayerName();
        
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif

    }
    void GetPlayerName()
    {
        
        ScoreManager.Instance.PlayerName = playerName.text;
    }

    void BestScore()
    {
        ScoreManager.Instance.LoadScore();
        topScore.text = "Best Score : " + ScoreManager.Instance.BestPlayer + " : " + ScoreManager.Instance.BestScore;
    }
    
}
