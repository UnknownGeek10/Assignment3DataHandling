using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthController : MonoBehaviour
{
    public GameObject Cross;
    public Text healthText;
    public Text AttentionText;
    public Text HungerText;
    public Text EnergyText;
    public Text CleanlinessText;

    public Image AttentionBar;
    public Image[] AttetionPoints;
    public Image HungerBar;
    public Image[] HungerPoints;
    public Image EnergyBar;
    public Image[] EnergyPoints;
    public Image CleanlinessBar;
    public Image[] CleanlinessPoints;
    public Image healthBar, ringHealthBar;
    public Image[] healthPoints;

    public static float damagePoints = 1f;
    
   
   public  float health, maxHealth = 100;
    public  float attention, MaxAttention = 10;
  public float hunger, MaxHunger = 10;
   public float energy, MaxEnergy = 100;
    public float cleanliness, maxCleanliness= 10;
    //public float InitialHealth;
    public float InitialAttention;
    public float InitialHunger;
    //public float InitialEnergy;
    public float InitialClean;

    public float lerpSpeed;
    public int k = 09;



    
    //float healingPoints;
   public float attentionPoints;
    public float energyPoints;
    public float hungerPoints;
    public float cleanlinessPoints;




    private void Start()
    {
        health = InitialHunger*7+InitialClean*3;
        attention = InitialAttention;
        hunger = InitialHunger;
        energy = InitialHunger*10;
        cleanliness = InitialClean;
    }

    private void Update()
    {
        attention = Mathf.Round(attention * 100) / 100;
        hunger = Mathf.Round(hunger * 100) / 100;
        energy = Mathf.Round(energy * 100) / 100;
        cleanliness = Mathf.Round(cleanliness * 100) / 100;
        health = Mathf.Round(health * 100) / 100;
        AttentionText.text = "Attention: " + attention + "/10";
        HungerText.text = "Hunger: " + hunger + "/10";
        EnergyText.text = "Energy: " + energy + "%";
        CleanlinessText.text = "Hygiene: " + cleanliness+"/10";
        healthText.text = "Health: " + health + "%";
       
        
        if (health > maxHealth) health = maxHealth;
        if (attention > MaxAttention) attention = MaxAttention;
        if (energy > MaxEnergy) energy = MaxEnergy;
        if (health > maxHealth) health = maxHealth;
        if (hunger > MaxHunger) hunger = MaxHunger;
        if (cleanliness > maxCleanliness) cleanliness = maxCleanliness;

        
       

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        AttentionBarFiller();
        HungerBarFiller();
        EnergyBarFiller();
        CleanBarFiller();
        ColorChanger();

        ApplyDamage();

        if (health == 0)
        {
            Destroy(healthBar);
            Destroy(AttentionBar);
            Destroy(EnergyBar);
            Destroy(HungerBar);
            Destroy(CleanlinessBar);
            healthText.enabled = false;
            AttentionText.enabled = false;
            EnergyText.enabled = false;
            CleanlinessText.enabled = false;
            HungerText.enabled = false;
            Cross.SetActive(true);

        }
        
        

    }

    public void ApplyDamage()
    {
        if (TimeManager.Hour >= k && TimeManager.Minute == 00 ) 
        {

            Damage();
            k++;
            if (k > 23)
            {
                k= 0;
            }
        
        }
        if (TimeManager.Hour >= 23 && TimeManager.Hour <= 06 &&  TimeManager.Minute == 00)
        {
            damagePoints = 0.5f;
            Damage(); 

        }
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);
        ringHealthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);

        for (int i = 0; i < healthPoints.Length; i++)
        {
            healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        }
    }
    void AttentionBarFiller()
    {
        AttentionBar.fillAmount = Mathf.Lerp(AttentionBar.fillAmount, (attention / MaxAttention), lerpSpeed);
        //ringHealthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);

        for (int i = 0; i < AttetionPoints.Length; i++)
        {
            AttetionPoints[i].enabled = !DisplayAttentionPoint(attention, i);
        }
    }

    void HungerBarFiller()
        {
            HungerBar.fillAmount = Mathf.Lerp(HungerBar.fillAmount, (hunger / MaxHunger), lerpSpeed);
            //ringHealthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);

            for (int i = 0; i < HungerPoints.Length; i++)
            {
                HungerPoints[i].enabled = !DisplayHungerPoint(hunger, i);
            }

        }

    void EnergyBarFiller()
    {
        EnergyBar.fillAmount = Mathf.Lerp(EnergyBar.fillAmount, (energy / MaxEnergy), lerpSpeed);
        

        for (int i = 0; i < EnergyPoints.Length; i++)
        {
            EnergyPoints[i].enabled = !DisplayEnergyPoint(energy, i);
        }
    }

    void CleanBarFiller()
    {
        CleanlinessBar.fillAmount = Mathf.Lerp(CleanlinessBar.fillAmount, (cleanliness / maxCleanliness), lerpSpeed);
        //ringHealthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);

        for (int i = 0; i < CleanlinessPoints.Length; i++)
        {
            CleanlinessPoints[i].enabled = !DisplayCleanlinessPoint(cleanliness, i);
        }
    }


    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
        ringHealthBar.color = healthColor;

        Color AttentionColor = Color.Lerp(Color.red, Color.green, (attention / MaxAttention));
        AttentionBar.color = AttentionColor;

        Color HungerColor = Color.Lerp(Color.red, Color.green, (hunger / MaxHunger));
        HungerBar.color = HungerColor;

        Color EnergyColor = Color.Lerp(Color.red, Color.green, (energy / MaxEnergy));
        EnergyBar.color = EnergyColor;

        Color CleanlinessColor = Color.Lerp(Color.red, Color.green, (cleanliness / maxCleanliness));
        CleanlinessBar.color = CleanlinessColor;
        //ringHealthBar.color = healthColor;
    }

    bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }

    bool DisplayAttentionPoint(float _Attention, int pointNumber)
    {
        return ((pointNumber * 10) >= _Attention);
    }

    bool DisplayHungerPoint(float _Hunger, int pointNumber)
    {
        return ((pointNumber * 10) >= _Hunger);
    }

    bool DisplayEnergyPoint(float _Energy, int pointNumber)
    {
        return ((pointNumber * 10) >= _Energy);
    }

    bool DisplayCleanlinessPoint(float _Clean, int pointNumber)
    {
        return ((pointNumber * 10) >= _Clean);
    }

     void Damage()
    {
        if (health > 0)
            health -= damagePoints;
        if (attention > 0)
            attention -= damagePoints/10;
        if (energy > 0) energy -= damagePoints;
        if (hunger > 0) hunger -= damagePoints/10;
        if (cleanliness > 0) cleanliness -= damagePoints/10;

        
    }
   /* public void Heal(float healingPoints = 10)
    {
        if (TimeManager.Hour == k && TimeManager.Minute == 00) { 
            if (Worker1Tog.isOn)
            {
                if (health < maxHealth) health += healingPoints;
                if (attention < MaxAttention) attention += healingPoints;
                if (energy < MaxEnergy) energy += healingPoints;
                if (hunger < MaxHunger) hunger += healingPoints;
                if (cleanliness < maxCleanliness) cleanliness += healingPoints;
                
            }
            k++;
        }
    }*/

    
}
