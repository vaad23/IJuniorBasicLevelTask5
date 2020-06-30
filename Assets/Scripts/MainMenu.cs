using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _score;
    [SerializeField] private DescriptionPanel _description;

    private void Awake()
    {
        int score = 0;

        if (PlayerPrefs.HasKey("Coins"))
            score = PlayerPrefs.GetInt("Coins");

        _score.text = $"Max Score: {score}";
    }

    public void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenDescription(bool isTrue)
    {
        _description.Open();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
