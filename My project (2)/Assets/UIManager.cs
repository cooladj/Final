using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public FuelBarController fuelBarController;
    public TextMeshProUGUI scoreText;

    public HealthBarController healthBarController;

    private void Start()
    {
        if(fuelBarController != null)
            fuelBarController.Initialize();

        if(healthBarController == null)
        {
            healthBarController = FindObjectOfType<HealthBarController>();
        }
    }

}
