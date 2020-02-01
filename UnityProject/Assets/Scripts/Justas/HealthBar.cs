using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem hpSystem;
    public void Setup(HealthSystem hpSystem)
    {
        this.hpSystem = hpSystem;
        hpSystem.OnHealthChange += HealthSystem_OnHealthChange;
    }
    private void HealthSystem_OnHealthChange(object sender, System.EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(hpSystem.GetHealthPercent(), 1);
    }
    private void Update()
    {
    }
}
