using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarController : MonoBehaviour
{

    public Image fuelBar;
    public TextMeshProUGUI timerText;

    private float maxFuel = 120f;
    private float currentFuel;
    private float fuelDecreaseRate = 100f / 120f;
    private float fuelIncreasePercentage = 25f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        currentFuel = maxFuel;
        UpdateFuelBar();
    }
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            currentFuel -= fuelDecreaseRate;
            timer = 0f;
            UpdateFuelBar();

            if(currentFuel == 0f)
            {
                GameOver();
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            IncreaseFuelByPercentage(fuelIncreasePercentage);
        }
    }

    void UpdateFuelBar()
    {
        fuelBar.fillAmount = currentFuel / maxFuel;
        timerText.text = "Fuel: " + Mathf.RoundToInt(currentFuel);
    }

    public void IncreaseFuelByPercentage(float percentage)
    {
        float increaseAmount = maxFuel * (percentage / 100f);
        currentFuel = Mathf.Min(maxFuel, currentFuel + increaseAmount);
        UpdateFuelBar();
    }

    void GameOver()
    {
        // Implement your game over logic here
        // For example, display a game over screen, stop player input, etc.
        Debug.Log("Game Over!");
        // You might want to call a method or event to handle game over actions.
    }
}
