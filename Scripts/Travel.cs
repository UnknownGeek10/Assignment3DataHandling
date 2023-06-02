using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Travel : MonoBehaviour

    
{
    

    
    public GameObject HomeButton;
    public GameObject ShopButton;
    //public GameObject DropButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    

   

    public void PlayGame()
    {
        SceneManager.LoadScene("Farm");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
