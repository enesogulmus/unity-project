using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    public int isGameStart = 0;
    public GameObject startGamePanel;
    public GameObject mainCube;
    public GameObject diamondPanel;
    public GameObject Icon;
    public Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
       
       
        animator.SetBool("Finger",true);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = isGameStart;
        
        
    }
    public void GameStart()
    {

        isGameStart = 1;
        startGamePanel.SetActive(false);
        Icon.SetActive(true);
        diamondPanel.SetActive(true);

        if (Input.GetMouseButton(0))
        {


            isGameStart = 1;
            startGamePanel.SetActive(false);
            Icon.SetActive(true);
            diamondPanel.SetActive(true);
        }
    }
    public void GameQuit()
    {


        Application.Quit();


    }
    public void PauseGame()
    {
        isGameStart = 0;


    } public void Continue()
    {
        isGameStart = 1;


    }
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
   
}
