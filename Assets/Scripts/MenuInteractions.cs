using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInteractions : MonoBehaviour
{
    public VicinityActivation shopVicinity;
    public GameObject shopPanel, napis;
    public Button defaultShopButton;

    public void OnSouth(InputValue ctx) {
        if (ctx.isPressed && shopVicinity.isWithin && !shopPanel.active) {
            napis.SetActive(false);
            Time.timeScale = 0;
            shopPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultShopButton.gameObject);
            defaultShopButton.Select();
        }
    }

    public void OnEast(InputValue ctx) {
        if (ctx.isPressed) {
            napis.SetActive(true);
            Time.timeScale = 1;
            shopPanel.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
        }
    }


}
