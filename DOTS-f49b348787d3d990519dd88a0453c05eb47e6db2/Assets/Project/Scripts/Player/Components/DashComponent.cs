using System.Collections;
using UnityEngine;

public class DashComponent : MonoBehaviour, IAbility
{
    public GameObject dashVFX;

    public float dashPower = 7f;

    public float dashCount = 5f;

    public float dashDaly;
    private float _dashTime = float.MinValue;

    public void Execute()
    {
        if (Time.time < _dashTime + dashDaly) return;

        var t = transform.position;
        for (int i = 0; i < dashCount; i++)
        {
            Vector3 dashPos = transform.forward;
            t += dashPos * dashPower * Time.deltaTime;
        }
        transform.position = t;

        _dashTime = Time.time;


    }
}