using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score, tokens;
    public enum typeGem {Red, Purple, Yellow};
    public int[] gemQuantity;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            score = 0;
            tokens = 0;
            gemQuantity = new int[Enum.GetNames(typeof(typeGem)).Length];
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
