using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInteractions : MonoBehaviour
{
    public VicinityActivation shopVicinity;
    public GameObject shopPanel;
    public Button defaultShopButton;

    public void OnSouth(InputValue ctx) {
        if (ctx.isPressed && shopVicinity.isWithin) {
            shopPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(defaultShopButton.gameObject);
            defaultShopButton.Select();
        }
    }

    public void OnEast(InputValue ctx) {
        if (ctx.isPressed) {
            shopPanel.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
        }
    }


}
