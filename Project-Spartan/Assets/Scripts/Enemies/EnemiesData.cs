using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemie Data", menuName = "Create Enemie Turtle Data")]
public class EnemiesData : ScriptableObject
{
    //DESING DATA
    [Header("CONFIGURACION DE MOVIMIENTO")]
    [Tooltip("VELOCIDAD ES DE 0.1 A 10")] 
    [SerializeField][Range(0.1F,10f)] public float speed = 0f;
    [Tooltip("VELOCIDAD ES DE 0.1 A 10")]
    [SerializeField][Range(0.1F,5f)]public float speedpatrol = 0f;
    [Header("CONFIGURACION DE DISPARO")]
    [SerializeField] public int shootCooldown = 1;
    [SerializeField] public float timetoAttack = 0;

    [Header("CONFIGURACION DE DIST PARA DETECTAR PLAYER")]
    [SerializeField] public float rayDist = 10f;
    
}
