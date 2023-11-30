using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManage : MonoBehaviour
{

    int levelOne = 4;
    int splashScreen = 0;
    int loginScreen = 1;
    int endScreen = 2;
    int registerScreen = 3;
      // Player is on SplashScreen. Player pushes 'login' button and redirected to LoginScreen
    public void LoginGame()
    {
        SceneManager.LoadScene(loginScreen);
    }
     

    //Player is on LoginScreen. If player sucessfully logins in, clicks on 'Play!' button then they are redirected to Sample(Game) Screen
    public void PlayGame()
    {
        SceneManager.LoadScene(levelOne);
    }


    //Player is on LoginScreen, clicks BacktoMenu button redirects to SplashScreen
    public void BacktoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);

    }


    //Player clicks 'Create Account" then is redirected to RegisterScreen
    public void CreateAcct()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

      
    //Player is on RegisterScreen. Player clicks on 'Play!' button, then redirected to Sample (Game) Screen
    public void PlayGameTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    //Player is on RegisterScree. Playclicks on 'BacktoMenu', then is redirected back to menu
    public void ReturntoMenuTwo() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndScreen()
    {
        SceneManager.LoadScene(endScreen);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(levelOne);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(loginScreen);
    }


}
