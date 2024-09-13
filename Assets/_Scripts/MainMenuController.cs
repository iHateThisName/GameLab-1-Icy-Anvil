using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _defaultMenu;
    [SerializeField] private GameObject _levelSelector;

    public void ActivateLevelSelector() {
        _defaultMenu.SetActive(false);
        _levelSelector.SetActive(true);
    }
    public void ActivateDefaultMenu() {
        _levelSelector.SetActive(false);
        _defaultMenu.SetActive(true);
    }
}
