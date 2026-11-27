using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TimerScript : MonoBehaviour
{
    //TEXT SERIALIZABLE
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI waveCounterText;
    [SerializeField] TextMeshProUGUI newWaveTimerText; //countdown to new wave; enable only upon wave threshold 

    //NUM SERIALIZABLE
    [SerializeField] float waveTime; //time between each wave
    [SerializeField] int waveNum; //number of waves

    //PRIVATE VARIABLES
    private float elapsedTime; //time+
    private float remainingTime = 10;

    //PUBLIC VARIABLES
    public int waveCounter = 0; 

    void Awake()
    {
        remainingTime = waveTime;
        newWaveTimerText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        //remainingTime -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        waveCounter = (Mathf.FloorToInt(elapsedTime/waveTime) + 1);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //always enabled
        waveCounterText.text = string.Format("Wave: {0}", waveCounter);
        
        if(waveCounter >= waveNum)
        {
            waveCounter = waveNum; //cap it permanently to waveNum

            waveCounterText.color = Color.red;
            waveCounterText.text = "Final Wave";
        }

    }
}
