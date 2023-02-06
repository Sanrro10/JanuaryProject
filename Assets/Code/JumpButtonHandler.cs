using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButtonHandler : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed;
    private bool isHold;

    public bool GetIsPressed()
    {
        return isPressed;
    }

    public bool GetIsHold()
    {
        return isHold;
    }

    // Start is called before the first frame update
    public void OnUpdateSelected(BaseEventData data)
    {
        isHold = isPressed;
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
