using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    [SerializeField] int health = 100;

    [SerializeField] GameObject player;

    private Slider HealthSlider;
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

    // public void button(){
    //   //When button pressed calls IncrementProgess
    //   //StudyButton -> Action-1 -> IncrementProgress(X)
    // }

    // public void DecrementProgress(float newProgress)
    // {
    //     //if the level is not 0 or if the lose of points won't bring progess <0,
    //     //decrease the points by newProgress
    //     if((targetProgress>0) && ((slider.value-newProgress)>0)){
    //       targetProgress = targetProgress - newProgress;
    //       Debug.Log("targetProgress is "+targetProgress);
    //     }
    //     Debug.Log("DecrementProgress method");
    //     Debug.Log("targetProgress is "+targetProgress);
    // }

    public void DecreaseHealth(int damage)
    {
        health-=damage;
        Debug.Log(damage+" points of damage taken");
    }

}
