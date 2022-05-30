using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagment : MonoBehaviour
{
    public static event Action OnPause;
    public static event Action OnResume;
    
    [SerializeField] private GameObject mPauseMenu;
    private void OnEnable()
    {
        OnPause += ShowPause;
        OnResume += HidePause;

    }
    
    private void OnDisable()
    {
        OnPause -= ShowPause;
        OnResume -= HidePause;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(mPauseMenu.activeSelf)
            {
                OnResume?.Invoke();
            }
            else
            {
                OnPause?.Invoke(); 
            }
            
        }
    }

    private void ShowPause()
    {
        mPauseMenu.SetActive(true);
    }

    private void HidePause()
    {
        mPauseMenu.SetActive(false);
    }

    public void Resume()
    {
        OnResume?.Invoke();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
