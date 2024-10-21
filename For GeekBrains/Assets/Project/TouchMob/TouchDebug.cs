using UnityEngine;

public class TouchDebug : MonoBehaviour
{
    private float startTimer;

    public bool MultiTouchCan;
    public bool TouchCan;
    public bool LongTouchCan;

    private void Update()
    {
        if(MultiTouchCan) MultiTouch();
        if(TouchCan) Touch();
        if(LongTouchCan) LongTouch();
    }

    private void MultiTouch()
    {
        for(int i = 0; i < Input.touches.Length; i++)
        {
            Debug.Log($"Touch: {i} {Input.touches[i].position}");
        }
    }

    private void Touch()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began) Debug.Log("Tap");
        }
    }

    private void LongTouch()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                startTimer = Time.time;
                Debug.Log("Tap1");
            }
            if(touch.phase == TouchPhase.Ended && Time.time - startTimer > 1.5f)
                Debug.Log("Lohn Tap!");
        }
    }
}
