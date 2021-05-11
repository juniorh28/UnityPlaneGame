using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthBar : MonoBehaviour
{

    [SerializeField] int health = 100;

    [SerializeField] GameObject player;

    private Slider HealthSlider;
    private Text healthText;
    private float targetProgress = 0;

    private void Awake(){
      HealthSlider = GameObject.FindGameObjectWithTag("HealthTag").GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //IncrementProgress(targetProgress);
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthSlider.value < health){
          HealthSlider.value = health;
        }

    }

    public void DecreaseHealth(int damage)
    {
        health-=damage;
        Debug.Log(damage+" points of damage taken");
        Debug.Log(health+" hp remaining");
        if(health<=0){
          Debug.Log("you died");
          Death();
        }
    }

    public void Death()
    {
      Destroy(player);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DisplayHealth()
    {
      healthText.text = "HP: "+health.ToString();
    }


}
