using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnackRound : MonoBehaviour
{
    public bool isActive;
    public int stage;
    public Quest quest;
    public QuestManager manager;
    public MakeCartFollow cart;

    [Space]
    public TMP_Text minPassengers;
    public TMP_Text maxPassengers;
    public GameObject passengerUI;
    [Space]

    [SerializeField] private List<StartConvo> BusinessClass;
    [SerializeField] private List<StartConvo> EconomyClass;

    // public StartConvo person;
    public BoxCollider door;

    private void Start()
    {
        isActive = false;
    }

    private void Update()
    {
        isActive = quest.isActive;

        if (isActive)
        {
            foreach (StartConvo convo in BusinessClass)
            {
                convo.allowedToShow = true;
            }

            stage = quest.currentObjective;
            switch (stage)
            {
                case 0:
                    if (cart.getPushCart())
                    {
                        manager.advanceQuest(quest);
                    }
                    break;
                case 1:
                    passengerUI.SetActive(true);
                    maxPassengers.text = "10";
                    int temp = 0;
                    foreach (StartConvo convo in BusinessClass)
                    {
                        if (convo.hasBeenShown)
                        {
                            temp++;
                        }
                        minPassengers.text = temp.ToString();
                    }
                    foreach (StartConvo convo in BusinessClass)
                    {
                        if (!convo.hasBeenShown)
                        {
                            return;
                        }
                    }
                    manager.advanceQuest(quest);
                    break;
                case 2:
                    passengerUI.SetActive(false);
                    door.enabled = true;
                    foreach (StartConvo convo in EconomyClass)
                    {
                        convo.allowedToShow = true;
                    }
                    break;
                case 3:
                    passengerUI.SetActive(true);
                    maxPassengers.text = "20";
                    int temp1 = 0;
                    foreach (StartConvo convo in EconomyClass)
                    {
                        if (convo.hasBeenShown)
                        {
                            temp1++;
                        }
                        minPassengers.text = temp1.ToString();
                    }
                    foreach (StartConvo convo in EconomyClass)
                    {
                        if (!convo.hasBeenShown)
                        {
                            return;
                        }
                    }
                    manager.advanceQuest(quest);
                    break;
            }
        }
        else
        {
            door.enabled = false;
            passengerUI.SetActive(false);
            foreach (StartConvo convo in BusinessClass)
            {
                convo.allowedToShow = false;
            }
            foreach (StartConvo convo in EconomyClass)
            {
                convo.allowedToShow = false;
            }
        }
    }
}
