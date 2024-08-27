using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public abstract IEnemy CreateEnemy(Vector3 position);
    public abstract IWeapon CreateWeapon(Vector3 position);
}
