using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData", order = 1)]
public class EnemyDataSO : ScriptableObject
{
    public string enemyName;
    public int health;
    public float speed;
}
