using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PolaroidTrigger : MonoBehaviour
{

    public bool playerInRange = false;

    public bool gotPolaroid = false;

    [SerializeField] private GameObject player;

// Start is called before the first frame update
    void Start()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && 
        !collision.gameObject.GetComponent<PlayerController>().isDead)
        {
            
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
         if (playerInRange==true && Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerController>().isDead == false)
        {
           gotPolaroid = true;
           int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if there are more scenes available
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Application.Quit();
        }
        }
    }
}
