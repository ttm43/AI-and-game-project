using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{

    public void LoadLevel(string Name)
    {
        SceneManager.LoadScene(Name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}
