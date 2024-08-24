using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinqExample : MonoBehaviour
{
	void Start()
	{
		int[] scores = { 90, 85, 70, 60, 95, 80 };

		// Simple Queries
		var highScores = from score in scores
						 where score > 80
						 select score;

		foreach (var score in highScores)
		{
			Debug.Log("Simple Queries. High Score: " + score);
		}

		// Method Syntax
		var highScores2 = scores.Where(score => score > 80);

		foreach (var score in highScores2)
		{
			Debug.Log("Method Syntax. High Score: " + score);
		}

		// Filtering Data. Where: Filters elements based on a condition.
		var evenNumbers = scores.Where(score => score % 2 == 0);

		foreach (var score in evenNumbers)
		{
			Debug.Log("Filtering Data. Even Number: " + score);
		}

		// Selecting Data. Select: Projects each element of a sequence into a new form.
		var squaredNumbers = scores.Select(n => n * n);

		foreach (var score in squaredNumbers)
		{
			Debug.Log("Selecting Data. Squared Number: " + score);
		}

		// Aggregating Data
		// Sum: Calculates the sum of the values
		int totalScore = scores.Sum();
		Debug.Log("Aggregating Data-Sum. Total Score: " + totalScore);

		// Count: Counts the elements that match a condition.
		int passingScores = scores.Count(score => score > 70);
		Debug.Log("Aggregating Data-Count. Passing Scores: " + passingScores);

		// Average: Calculates the average of the values.
		double averageScore = scores.Average();
		Debug.Log("Aggregating Data-Average. Average Score: " + averageScore);

		// Ordering Data
		// OrderBy: Sorts elements in ascending order.
		var orderedScore = scores.OrderBy(score => score);

		foreach (var score in orderedScore)
		{
			Debug.Log("Ordering Data-OrderBy. Ordered Score: " + score);
		}

		// OrderByDescending: Sorts elements in descending order.
		var orderedScoresDescending = scores.OrderByDescending(score => score);

		foreach (var score in orderedScoresDescending)
		{
			Debug.Log("Ordering Data-OrderByDescending. Ordered Score: " + score);
		}

	}



}
