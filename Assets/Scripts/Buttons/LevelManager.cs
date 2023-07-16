using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{
    public AudioSource ButtonSelectSound;
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
        ButtonSelectSound.Play(); //Solo Copien y peguen esto en donde vayan a poner lo que hace cada boton
        SceneManager.LoadScene(level1);

    }

    public void Level2()
    {
        ButtonSelectSound.Play();
        SceneManager.LoadScene(level2);
    }

    public void Controls()
    {
        ButtonSelectSound.Play();
        SceneManager.LoadScene(controls);
    }

    public void Close()
    {
        ButtonSelectSound.Play();
        Application.Quit();
        
    }

    
}
