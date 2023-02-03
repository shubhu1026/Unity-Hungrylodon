using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIAboutWindowScript : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void CloseWindow()
    {
        mainMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
