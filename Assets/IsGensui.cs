using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGensui : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (transform.parent.GetComponent<Enemy>().IsGong)
            return;
        if (collision.tag == "Enemy")
        {
           EnemyType enemyType=collision.GetComponent<EnemyType>();
            if (enemyType.thisType == EnemyType.ThisType.fowl && collision.GetComponent<Enemy>().IsGong)
            {
                transform.parent.GetComponent<Enemy>().Gensu(collision.transform);
                Debug.Log(11);
                GetComponent<IsGensui>().enabled = false;
            }
        }
    }

}
