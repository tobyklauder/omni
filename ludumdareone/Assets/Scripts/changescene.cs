using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
    }
 
    public void loadGame()
    {
        SceneManager.LoadScene("mainscene", LoadSceneMode.Single);
    }
    public void loadGameOver()
    {
        SceneManager.LoadScene("gameover", LoadSceneMode.Single);
    }

}
