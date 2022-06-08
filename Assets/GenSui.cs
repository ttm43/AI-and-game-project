using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenSui : MonoBehaviour
{
    public Transform Boss;


    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Boss.position;
    }
}
