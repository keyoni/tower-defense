using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MouseClicker.EnemyHit += EnemyGotHit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnemyGotHit(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().Hit();
    }
}
