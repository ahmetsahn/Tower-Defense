using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController Instance { get; private set; }

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private TextMeshProUGUI healthText;
    
    [SerializeField]
    private int currentHealth;
    public int CurrentHealth => currentHealth;

    [SerializeField]
    private TextMeshProUGUI energyText;
    
    [SerializeField]
    private int currentEnergy;
    public int CurrentEnergy => currentEnergy;

    [SerializeField]
    private Button[] towerButtons;

    [SerializeField]
    private int machineGunEnergy;

    [SerializeField]
    private int rocketEnergy;

    [SerializeField]
    private int laserEnergy;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable() => AddListeners();

    

    private void OnDisable() => RemoveListeners();

    

    private void Start()
    {
        UpdateHealthText();
        UpdateEnergyText();
        ButtonInteractableControl();
    }


    public void StartWaveButton()
    {
        GameEvents.LoadStartWave();
        startButton.interactable = false;
    }

    public void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
    }

    public void UpdateEnergyText()
    {
        energyText.text = currentEnergy.ToString();
    }

    public void ReduceHealth()
    {
        currentHealth--;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void ReduceEnergy(int energy)
    {
        currentEnergy -= energy;

        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }

        ButtonInteractableControl();

    }

    public void IncreaseEnergy(int energy)
    {
        currentEnergy += energy;
        ButtonInteractableControl();
    }

    public void ButtonInteractableControl()
    {
        for (int i = 0; i < towerButtons.Length; i++)
        {
            if (currentEnergy < towerButtons[i].GetComponent<TowerButton>().EnergyCost)
            {
                towerButtons[i].interactable = false;
            }
            else
            {
                towerButtons[i].interactable = true;
            }
        }
    }

    public void ButtonUseable()
    {
        for (int i = 0; i < towerButtons.Length; i++)
        {
            towerButtons[i].interactable = true;
        }
    }

    public void ButtonNotUseable()
    {
        for (int i = 0; i < towerButtons.Length; i++)
        {
            towerButtons[i].interactable = false;
        }
    }

    private void AddListeners()
    {
        GameEvents.OnTowerButtonUseable += ButtonUseable;
        GameEvents.OnTowerButtonNotUseable += ButtonNotUseable;
    }

    private void RemoveListeners()
    {
        GameEvents.OnTowerButtonUseable -= ButtonUseable;
        GameEvents.OnTowerButtonNotUseable -= ButtonNotUseable;
    }


}
