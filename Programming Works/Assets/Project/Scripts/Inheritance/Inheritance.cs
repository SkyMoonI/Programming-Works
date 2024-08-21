using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inheritance : MonoBehaviour
{
	Animal _animal = new Animal();
	Dog _dog = new Dog();
	Cat _cat = new Cat();

	[SerializeField] Player _player;
	[SerializeField] Enemy _enemy;

	Circle circle = new Circle();
	Rectangle rectangle = new Rectangle();

	[SerializeField] Player2 _player2;
	[SerializeField] Enemy2 _enemy2;

	[SerializeField] Coin _coin;
	[SerializeField] HealthPotion _healthPotion;
	// Start is called before the first frame update
	void Start()
	{
		_animal.MakeSound();
		_dog.MakeSound();
		_cat.MakeSound();

		_player.TakeDamage(10f);
		Debug.Log("Player Health: " + _player.Health);
		_enemy.TakeDamage(10f);
		Debug.Log("Enemy Health: " + _enemy.Health);

		circle.radius = 5f;
		rectangle.length = 10f;
		rectangle.width = 5f;

		Debug.Log("Circle Area: " + circle.CalculateArea());
		Debug.Log("Circle Perimeter: " + circle.CalculatePerimeter());
		Debug.Log("Rectangle Area: " + rectangle.CalculateArea());
		Debug.Log("Rectangle Perimeter: " + rectangle.CalculatePerimeter());

		Debug.Log("Player2 Health: " + _player2.Health);
		_player2.TakeDamage(10f);
		Debug.Log("Player2 Health: " + _player2.Health);
		_player2.Attack(_enemy2, 10f);
		Debug.Log("Enemy2 attacked by Player2. Health: " + _enemy2.Health);


		_player2.CollectItem(_coin);
		_player2.CollectItem(_healthPotion);
	}

}
