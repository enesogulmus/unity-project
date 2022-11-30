using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   // public int isGameStart = 0;
    public GameObject player;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public Animator animator;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // Time.timeScale = isGameStart;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {


            gameOverPanel.SetActive(true);
            gameController.isGameStart = 0;
            animator.Play("Death");
          
        }
        if (other.CompareTag("FinishCube"))
        {


            winPanel.SetActive(true);
            gameController.isGameStart = 0;
            animator.SetBool("Win", true);

        }


    }

  
   
}
