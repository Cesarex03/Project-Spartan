using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField] Text textGemYellow;
    [SerializeField] Text textGemPurple;
    [SerializeField] Text textGemRed;
    [SerializeField] Text textScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateGemUI();
        UpdateScoreUI();
    }

    private void UpdateGemUI()
    {
        int[] GemCounts = GameManager.instance.gemQuantity;
        textGemYellow.text = "x " + GemCounts[0];
        textGemPurple.text = "x " + GemCounts[1];
        textGemRed.text = "x " + GemCounts[2];
    }
    private void UpdateScoreUI()
    {
        textScore.text = " " + GameManager.instance.score;
        
    }
}
