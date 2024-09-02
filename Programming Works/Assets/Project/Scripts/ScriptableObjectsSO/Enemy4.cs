using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    [SerializeField] EnemyDataSO enemyData;

    void Start()
    {
        // Use the data from the ScriptableObject
        Debug.Log("Enemy Name: " + enemyData.enemyName);
        Debug.Log("Enemy Health: " + enemyData.health);
        Debug.Log("Enemy Speed: " + enemyData.speed);
    }

}
