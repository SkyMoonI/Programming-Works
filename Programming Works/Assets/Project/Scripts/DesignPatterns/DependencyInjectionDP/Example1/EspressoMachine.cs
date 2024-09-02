using UnityEngine;

public class EspressoMachine : ICoffeeMachine
{
    public void Brew() => Debug.Log("Brewing espresso...");

}
