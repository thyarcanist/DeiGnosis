using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    // The Alpha and Omega: The Dice Mechanic
    public int dieSide; // 1 - 20
    public string dieCode = $"BASE DIE";
    public AudioClip redHerring; // audioClip associated

    public GameObject thisDie;
    public AudioSource thisSource;
    public Text theDiceText;

    private void Start()
    {
        GetObjectReference();
    }

     void Update()
    {
        UpdateUI();  
    }

    private void GetObjectReference()
    {
        thisDie = gameObject;
        thisSource = GetComponent<AudioSource>();
    }

    private void UpdateUI()
    {
        theDiceText = GameObject.FindGameObjectWithTag("DiceText").GetComponent<Text>();
        theDiceText.text = dieSide.ToString();
    }
}
