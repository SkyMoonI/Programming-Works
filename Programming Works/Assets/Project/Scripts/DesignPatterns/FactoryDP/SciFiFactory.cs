using UnityEngine;

public class SciFiFactory : Factory
{
	[SerializeField] LaserGun _laserGunPrefab;
	[SerializeField] Robot _robotPrefab;

	public override IEnemy CreateEnemy(Vector3 position)
	{
		GameObject robotInstance = Instantiate(_robotPrefab.gameObject, position, Quaternion.identity);
		Robot newRobot = robotInstance.GetComponent<Robot>();

		newRobot.Initialize();
		newRobot.Attack();

		return newRobot;
	}

	public override IWeapon CreateWeapon(Vector3 position)
	{
		GameObject laserGunInstance = Instantiate(_laserGunPrefab.gameObject, position, Quaternion.identity);
		LaserGun newLaserGun = laserGunInstance.GetComponent<LaserGun>();

		newLaserGun.Initialize();
		newLaserGun.Use();

		return newLaserGun;
	}
}
