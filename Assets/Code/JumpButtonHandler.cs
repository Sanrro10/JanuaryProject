using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed;

    public bool GetIsPressed()
    {
        return isPressed;
    }

    public bool GetIsHold()
    {
        // Directly return the isPressed status for the hold check.
        return isPressed;
    }

    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
}
