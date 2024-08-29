using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public string powerUpName;
    public float duration;

    public abstract void Activate(GameObject player);
    public abstract void Deactivate(GameObject player);

}
