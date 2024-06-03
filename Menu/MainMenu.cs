using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject PlayMenu;
    [SerializeField] private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }   
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
    public void Play()
    {
        ani.SetTrigger("start");
        PlayMenu.SetActive(true);
    }    
}
