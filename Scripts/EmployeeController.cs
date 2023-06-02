using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class EmployeeController : MonoBehaviour
{
    public HealthController HealthController;
    // public float healingPoints;
    public float attentionPoints;
    public float energyPoints;
    public float hungerPoints;
    public float cleanlinessPoints;
    public TextMeshProUGUI HealthAddedText;
    public TextMeshProUGUI AttentionAddedText;
    public TextMeshProUGUI HungerAddedText;
    public TextMeshProUGUI EnergyAddedText;
    public TextMeshProUGUI HygieneAddedText;


    public GameObject Animal;

    public Toggle WorkerTog;
    public GameObject Worker;
    public GameObject ReturnWorker;


    float A;
    float B;
    float C;
    float D;
    float E;




    

    public void Start()
    {
        Worker.SetActive(false);
        ReturnWorker.SetActive(false);



    }

    public void Update()
    {
        HealthController = GetComponent<HealthController>();
        //transform.position = Vector2.MoveTowards(transform.position,Animal.transform.position,Speed*Time.deltaTime);

        if (TimeManager.Hour >= 20 && TimeManager.Hour >= 8)
        {
            WorkerTog.isOn = false;
            WorkerTog.interactable = false;

        }
        if (TimeManager.Hour <= 8 && TimeManager.Hour <= 20)
        {
            WorkerTog.interactable = true;
        }

       



    }

    void Heal()
    {


        if (HealthController.health < HealthController.maxHealth) HealthController.health = HealthController.hunger * 7 + HealthController.cleanliness * 3;
        if (HealthController.attention < HealthController.MaxAttention) HealthController.attention += attentionPoints / 60;
        if (HealthController.energy < HealthController.MaxEnergy) HealthController.energy = HealthController.hunger * 10;
        if (HealthController.hunger < HealthController.MaxHunger) HealthController.hunger += energyPoints / 60;
        if (HealthController.cleanliness < HealthController.maxCleanliness) HealthController.cleanliness += cleanlinessPoints / 60;

        A = HealthController.hunger * 7 + HealthController.cleanliness * 3;
        B = attentionPoints / 60;
        C = energyPoints / 60;
        D = HealthController.hunger * 10;
        E = cleanlinessPoints / 60;


        Worker.SetActive(true);

        HealthAddedText.text = "+" + A.ToString();
        AttentionAddedText.text = "+"+ B.ToString();
        HungerAddedText.text = "+"+ C.ToString();
        EnergyAddedText.text = "+"+ D.ToString();
        HygieneAddedText.text = "+"+ A.ToString();



    }

    public void ApplyHeal()
    {
        if (WorkerTog.isOn)
        {

            InvokeRepeating("Heal", 10f, 1f);
            Debug.Log("Working...");

        }
        if (!WorkerTog.isOn)
        {
            HealthController.damagePoints = 0.5f;
            CancelInvoke();
            Debug.Log("Worker Dismissed");
            ReturnWorker.SetActive(true);
        }

    }


   
}
