using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create delegate
public delegate void ExperienceGained(int experiencePoints);

public class PlayerStats
{
	// create delegate variable
	public ExperienceGained OnExperinceGained;

	public void GainExperience(int experiencePoints)
	{
		OnExperinceGained?.Invoke(experiencePoints);
	}
}
