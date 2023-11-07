using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public float FoodCounter
    {
        get
        {
            return _foodCounter;
        }

        set
        {
            if(value <= 0f)
            {
                _foodCounter = 0f;
            }

            else
                _foodCounter= value;
        }
    }

    [SerializeField] private float _foodCounter = 110f;

    private float foodTreshold = 100f;

    public GameObject CurrentFoodTarget { get; private set; }

    private void Update()
    {
        ConsumeFood();
    }

    private void ConsumeFood()
    {
        FoodCounter -= Time.deltaTime;
    }

    public void LookForFood()
    {
        GameObject food = GameObject.Find("Food");

        if (food != null)
            CurrentFoodTarget = food;
    }

    public void EatFood()
    {
        if(CurrentFoodTarget != null)
        {
            FoodCounter += 25f;

            Destroy(CurrentFoodTarget);
        } 
    }

    public bool FoodCounterHighEnough()
    {
        return _foodCounter >= foodTreshold;
    }
}
