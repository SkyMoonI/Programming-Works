using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData1", order = 0)]
public class EnemyData : ScriptableObject
{
	public float _maxHealth;
	public float _maxSpeed;
	public float _attackDamage;
	public float _attackSpeed;
	public float _attackRange;

}
