using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class activeButton : MonoBehaviour
{
    DefenderInfo defender = new DefenderInfo();
    public Button button;
    public bool ativeButton;

    void Update()
    {
        interactable();
    }

    public void interactable()
    {
        if (PlayerStats.money > defender.towerCost)
        {
            button.interactable = true;
            ativeButton = true;
        }
        else
        {
            button.interactable = false;
            ativeButton = false;
        }
    }
}
