using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject ShengliGame;

    // Start is called before the first frame update
    void Start()
    {
            Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = 0;
            ShengliGame.SetActive(true);

        }
    }
}
