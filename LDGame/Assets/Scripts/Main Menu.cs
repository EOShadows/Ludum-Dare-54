using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator anime;
    private string scene = "";

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click_play(string scene)
    {
        this.scene = scene;
        anime.SetTrigger("fade_to_scene");
    }

    public void click_quit()
    {
        Application.Quit();
    }

    public void toScene()
    {
        SceneManager.LoadScene(scene);
    }
}
