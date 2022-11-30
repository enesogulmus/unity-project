using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Cube : MonoBehaviour
{
    public GameController gameController;
    public Collector collector;
    public bool isTouch = false;
    public bool blockTouch = false;
    public GameObject winPanel;
    public TextMeshProUGUI diamondPanel;
    public int diamond;
    public int level = 0;
    public Animator animator;
    public AudioSource FireSound;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.SetInt("diamond", 0);
        diamond = PlayerPrefs.GetInt("diamond");
        diamondPanel.SetText(diamond.ToString());
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextLevel()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("level"));
        Time.timeScale = 1;

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Block") && blockTouch == false)
        {

            transform.parent = null;
            
            collector.lowHeight();
            blockTouch = true;

        }
        if (other.CompareTag("FinishCube") && other.GetComponent<FinishCube>().isTouchToFinish == false)
        {
            transform.parent = null;
            other.GetComponent<FinishCube>().isTouchToFinish = true;
            other.GetComponent<BoxCollider>().isTrigger = false;

        }
        if (other.CompareTag("Win"))
        {

            
            winPanel.SetActive(true);
            gameController.isGameStart = 0;
            level++;
            PlayerPrefs.SetInt("level", level);
            animator.SetBool("Win", true);
            gameController.isGameStart = 0;


            if (PlayerPrefs.GetInt("level") >= 3)
            {
                PlayerPrefs.SetInt("level", 0);
            }


        }
        if (other.CompareTag("Diamond"))
        {

            diamond++;
            diamondPanel.SetText(diamond.ToString());
            FireSound.Play();
            other.gameObject.SetActive(false);
            PlayerPrefs.SetInt("diamond", diamond);

        }



    }

}
