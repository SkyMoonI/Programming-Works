using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	CombatSystem _combatSystem;
	GameManager2 _gameManager2;
	Player3 _player3;
	PlayerDamage _playerDamage;
	PlayerHealth2 _playerHealth2;
	PlayerStats _playerStats;
	PlayerLevel _playerLevel;

	void Start()
	{
		// Initialize components
		_combatSystem = new CombatSystem();
		_gameManager2 = new GameManager2();
		_player3 = new Player3();
		_playerDamage = new PlayerDamage();
		_playerHealth2 = new PlayerHealth2();
		_playerStats = new PlayerStats();
		_playerLevel = new PlayerLevel();

		// Subscribe to events and delegates

		// 1. Delegate Example
		_playerStats.OnExperinceGained = xp => Debug.Log($"Gained {xp} XP!");

		// 2. Delegate with Return Type
		_playerHealth2.OnHeal = (currentHealth, healAmount) => currentHealth + healAmount;

		// 3. Event with Custom EventArgs
		_playerLevel.OnLevelUp += (sender, args) =>
		{
			Debug.Log($"Level up! New level: {args.NewLevel}");
		};

		// 4. Action Event
		_playerDamage.OnPlayerDamaged += () => Debug.Log("Player took damage!");

		// 5. Action with Parameters
		_player3.OnHealAction = (currentHealth, healAmount) =>
		{
			Debug.Log($"Healing from {currentHealth} by {healAmount}.");
		};

		// 6. Func Delegate
		_combatSystem.CalculateDamage = (baseDamage, armor) => baseDamage - armor;

		// 7. EventHandler
		_gameManager2.OnGameOver += (sender, args) =>
		{
			Debug.Log("Game Over Event Triggered!");
		};

		// Simulate actions
		_playerStats.GainExperience(100);
		_playerHealth2.Heal(20);
		_playerLevel.LevelUp();
		_playerDamage.TakeDamage(10);
		_player3.Heal(50, 10);
		_combatSystem.CalculateDamage(30, 5);
		_gameManager2.EndGame();
	}
}
