using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] randTrans;
    public GameObject[] enemyWaves;

    private GameObject enemyWave;
    private bool isCompleted;

    private int randWaveNum;

    [HideInInspector] public int waveNum;

    private void Awake()
    {
        waveNum = 1;
    }

    private void Start()
    {
        InstaceDiren();
    }

    void InstaceDiren()
    {
        Invoke("InstaceDiren", 5f);
        int randPosNum = Random.Range(0, randTrans.Length);
        int randPosNums = Random.Range(0, enemyWaves.Length);

        enemyWave = Instantiate(enemyWaves[randPosNums], randTrans[randPosNum].position, Quaternion.identity);
        enemyWave.SetActive(true);
    }


    private void Update()
    {
       
    }
}
