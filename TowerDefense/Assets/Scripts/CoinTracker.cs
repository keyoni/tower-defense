using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    private TextMeshProUGUI _coinText;

    private int _currentCoin = 0;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyDied += EnemyDrops;
        _coinText = GetComponent<TextMeshProUGUI>();
        _coinText.text = _currentCoin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyDrops(Enemy enemy)
    {
        _currentCoin += enemy.coins;
        _coinText.text = _currentCoin.ToString();
    }
}
