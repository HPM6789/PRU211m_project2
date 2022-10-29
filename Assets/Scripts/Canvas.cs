using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    [SerializeField]
    Text goldText;
    int goldTotal;
    string goldPrefix = "Gold: ";
    [SerializeField]
    Text healthText;
    int healthTotal;
    string healthPrefix = "Health: ";
    [SerializeField]
    Text waveText;
    int waveTotal;
    string wavePrefix = "Wave: ";
    // Start is called before the first frame update
    void Start()
    {
        goldTotal = 0;
        printGold(0);
        healthTotal = 1000;
        printHealth(0);
        waveTotal = 1;
        printWave(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void printGold(int gold)
    {
        goldTotal += gold;
        goldText.text = goldPrefix + goldTotal.ToString();
    }

    public void printHealth(int health)
    {
        healthTotal += health;
        healthText.text = healthPrefix + healthTotal.ToString();
    }

    public void printWave(int wave)
    {
        waveTotal += wave;
        waveText.text = wavePrefix + waveTotal.ToString();
    }
}
