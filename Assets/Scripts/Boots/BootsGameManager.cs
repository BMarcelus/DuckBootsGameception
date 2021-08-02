using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BootsGameManager : GameManager
{
    protected bool isGameRunning = false;

    protected int maxCustomerAmount;
    protected int currCustomerAmount = 0;
    protected bool isSpawning = true;
    protected int satisfiedCustomer = 0;

    protected float timer;
    protected float waitTime;
    protected float endTime;

    public GameObject GoalGameObject;

    protected CustomerSpawner[] customerSpawners;

    protected override void Awake()
    {
        customerSpawners = GetComponentsInChildren<CustomerSpawner>();
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
        if (isGameRunning)
        {
            timer += Time.deltaTime;

            if (timer > endTime)
            {
                SpawnCustomer();
                ResetTimer();
            }
        }
    }

    public override void EnableGame(GameManager parentGame)
    {
        base.EnableGame(parentGame);
        ResetGame();
    }

    public override void DisableGame()
    {
        base.DisableGame();
        isGameRunning = false;
    }

    private void ResetTimer()
    {
        timer = Time.time;
        waitTime = UnityEngine.Random.Range(3f, 5f);
        endTime = timer + waitTime;
    }

    private void ResetGame()
    {
        isGameRunning = true;
        ResetTimer();
        currCustomerAmount = 0;
        satisfiedCustomer = 0;
        maxCustomerAmount = UnityEngine.Random.Range(5, 8);
        isSpawning = true;
        GoalGameObject.SetActive(false);
        ReturnPlayerToEntry();
        DestroyAllCustomers();
    }

    private void SpawnCustomer()
    {
        if (!isSpawning) { return; }

        int cusInd = UnityEngine.Random.Range(0, customerSpawners.Length);
        CustomerSpawner currSpawner = customerSpawners[cusInd];

        ColorType randColor;
        do
        {
            Array values = Enum.GetValues(typeof(ColorType));
            System.Random random = new System.Random();
            randColor = (ColorType)values.GetValue(random.Next(values.Length));
        } while (randColor == ColorType.Black);

        currSpawner.SpawnCustomer(randColor);

        currCustomerAmount++;
        if (currCustomerAmount >= maxCustomerAmount)
        {
            isSpawning = false;
        }
    }

    public void OnCustomerRemove(bool isSatisfied)
    {
        if (!isSatisfied)
        {
            GameOver(false);
            return;
        }
        else
        {
            satisfiedCustomer++;
            if (satisfiedCustomer >= maxCustomerAmount)
            {
                GameOver(true);
            }
        }
    }

    public void GameOver(bool hasWon)
    {
        if (hasWon)
        {
            GoalGameObject.SetActive(true);
            isGameRunning = false;
        }
        else
        {
            ResetGame();
        }
    }

    private void DestroyAllCustomers()
    {
        foreach (CustomerSpawner cs in customerSpawners)
        {
            cs.RemoveAllCustomers();
        }
    }
}
