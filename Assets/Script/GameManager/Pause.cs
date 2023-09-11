using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isPaused = false;

    public void ClickToPause()
    {        
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }        
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; 
     
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; 
   
    }
}