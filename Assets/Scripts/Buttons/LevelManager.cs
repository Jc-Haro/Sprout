using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{
    public string level1;
    public string level2;
    public string controls;
   
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        SceneManager.LoadScene(level1);

    }

    public void Level2()
    {
        SceneManager.LoadScene(level2);
    }

    public void Controls()
    {
        SceneManager.LoadScene(controls);
    }

    public void Close()
    {
        Application.Quit();
        
    }

    
}
