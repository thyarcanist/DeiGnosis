using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BodySystem : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth;
    private float currentStamina;
    private float maxStamina;

    private float currentEnergy;
    private float maxEnergy = 100;

    private float currentRestfulness;
    private float maxRestfulness;

    private bool bCurrentlySleeping = false;

    private float currentWasteAmount;
    private float maxWasteAmount;

    private float maxStomachContent;
    private float currentStomachContent;

    private void Awake()
    {
        OnCharacterInit();
    }

    private void OnCharacterInit()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentEnergy = maxEnergy;
        currentRestfulness = maxRestfulness;
        currentWasteAmount = 0;
        currentStomachContent = 80;
    }


    private float digestTime;
    private bool isFinishedEating;
    public bool bCurrentlyEatingFood(bool CharacterEating, int HealingAmountBase, float PassiveHealing)
    {
        if (CharacterEating)
        {
            return true;
        }

        return false;
    }

    public void DigestiveExchange()
    {
        if (isFinishedEating)
        {
            // Increase currentStomachContent by a set amount
            currentStomachContent += digestTime;
            // Increase currentWasteAmount by a set amount
            currentWasteAmount += digestTime;
            // Decrease currentEnergy by a set amount
            currentEnergy -= digestTime;
        }
        // Clamp all values
        ClampingBodyValues();
    }

    public void ReplenishStamina()
    {
        // If current energy is above 40%, replenish currentStamina
        if (currentEnergy >= 40)
        {
            currentStamina += 5;
        }
        // Clamp all values
        ClampingBodyValues();
    }

    public void ReplenishHealth()
    {
        // If bCurrentlySleeping is true and currentRestfulness is at or above 80%, increase currentHealth
        if (bCurrentlySleeping && currentRestfulness >= 80)
        {
            currentHealth += 5;
        }
        // Clamp all values
        ClampingBodyValues();
    }
    private void ClampingBodyValues()
    {
        Mathf.Clamp(currentHealth, 0, maxHealth);
        Mathf.Clamp(currentStamina, 0, maxStamina);
        Mathf.Clamp(currentEnergy, 0, maxEnergy);
        Mathf.Clamp(currentRestfulness, 0, maxRestfulness);
        Mathf.Clamp(currentWasteAmount, 0, maxWasteAmount);
        Mathf.Clamp(currentStomachContent, 0, maxStomachContent);
    }
}