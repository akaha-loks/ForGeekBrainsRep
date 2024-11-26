using UnityEngine;

public class DashComponent : MonoBehaviour, IAbility
{
    public GameObject dashVFX;

    public float dashPower = 7f;

    public float dashDaly;
    private float _dashTime = float.MinValue;

    public bool canDash = true;

   /* public void Dashing()
    {
        if (Time.time < _dashTime + dashDaly) return;
        
        _dashTime = Time.time;
        canDash = false;
        dashVFX.SetActive(false);

        if (dashVFX == null)
        {
            Debug.LogError("[SHOOT ABILITY] No link dash");
        }
    }
    */
    public void Execute()
    {
        Debug.Log("NO Dash");
        if (Time.time < _dashTime + dashDaly) return;

        _dashTime = Time.time;
        canDash = true;
        dashVFX.SetActive(true);

        Debug.Log("Dash");

        if (dashVFX == null)
        {
            Debug.LogError("[SHOOT ABILITY] No link dash");
        }
    }
}