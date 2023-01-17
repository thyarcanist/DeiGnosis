using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public Transform parentDiePosition;
    public GameObject parentDieObject;
    public GameObject[] dieSides;

    private int DieAmount;

    private void Start()
    {
        GetDieParentReference();
        // sets the length to the amount of gameobjects in dieSides
        DieAmount = dieSides.Length;
    }

    private void GetDieParentReference() 
    { 
        // gets the location of the base object and sets it to the parent position
        parentDieObject = GameObject.FindGameObjectWithTag("baseTransform");
        parentDiePosition = parentDieObject.transform;
    }
}
