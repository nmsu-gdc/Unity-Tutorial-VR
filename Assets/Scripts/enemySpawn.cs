using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour 
{
    public Rigidbody enemy;
    public float delay;
    public bool determineSpawn;

    void Start()
    {
        StartCoroutine("DoCheck");
    }

    IEnumerator DoCheck()
    {
        for (int x = 0;x <20 ;x++ )
        {
            determineSpawn = randomSpawn();
            if (determineSpawn == true)
            {
                Rigidbody iP = Instantiate(enemy, transform.position, transform.rotation) as Rigidbody;
            }
            yield return new WaitForSeconds(delay);
        }
    }

    bool randomSpawn(){
        
        System.Random ran = new System.Random();
        int i = ran.Next(0, 3);
        bool temp = false;

        if (i == 0)
        {
            temp = true;
        }
        else if(i == 1)
        {
            temp = false;
        }
        else if (i == 2)
        {
            temp = true;
        }
        else if (i == 3)
        {
            temp = false;
        }
        return temp;
    }
}
