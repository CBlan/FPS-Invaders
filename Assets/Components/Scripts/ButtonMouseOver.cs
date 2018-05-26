using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Motion_RotateUI outRingRotate;
    public Motion_RotateUI midRingRotate;
    public Motion_RotateUI inRingRotate;
    public Motion_RotateUI midBlip1Rotate;
    public Motion_RotateUI midBlip2Rotate;
    public Motion_RotateUI outBlip1Rotate;
    public Motion_RotateUI outBlip2Rotate;

    void Start()
    {
        outRingRotate.RotateSpeed = 110;
        midRingRotate.RotateSpeed = -100;
        inRingRotate.RotateSpeed = 90;
        midBlip1Rotate.RotateSpeed = -110;
        midBlip2Rotate.RotateSpeed = 100;
        outBlip1Rotate.RotateSpeed = 110;
        outBlip2Rotate.RotateSpeed = -100;
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        outRingRotate.RotateSpeed = 210;
        midRingRotate.RotateSpeed = -200;
        inRingRotate.RotateSpeed = 180;
        midBlip1Rotate.RotateSpeed = -210;
        midBlip2Rotate.RotateSpeed = 200;
        outBlip1Rotate.RotateSpeed = 210;
        outBlip2Rotate.RotateSpeed = -200;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        outRingRotate.RotateSpeed = 110;
        midRingRotate.RotateSpeed = -100;
        inRingRotate.RotateSpeed = 90;
        midBlip1Rotate.RotateSpeed = -110;
        midBlip2Rotate.RotateSpeed = 100;
        outBlip1Rotate.RotateSpeed = 110;
        outBlip2Rotate.RotateSpeed = -100;
    }
}
