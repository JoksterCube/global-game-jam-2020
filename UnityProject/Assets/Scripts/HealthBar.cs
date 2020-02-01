using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem hpSystem;
    public void Setup(HealthSystem hpSystem)
    {
        this.hpSystem = hpSystem;
    }
    private void Update()
    {
        transform.Find("Bar").localScale = new Vector3(hpSystem.GetHealthPercent(), 1);
    }
}
