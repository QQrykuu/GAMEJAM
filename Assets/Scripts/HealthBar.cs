using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private HealthSystem HealthSystem;
    private Transform BarTransform;
    private Transform SeparatorContainer;

    private void Awake()
    {
        BarTransform = transform.Find("Bar");
    }

    private void Start()
    {
        SeparatorContainer = transform.Find("SeparatorContainer");
        ConstructHealthBarSeparators();

        HealthSystem.OnDamaged += HealthSystem_OnDamaged;
        HealthSystem.OnHealed += HealthSystem_OnHealed;
        HealthSystem.OnHealthAmountMaxChanged += HealthSystem_OnHealthAmountMaxChanged;

        UpdateHealthbar();
        UpdateBarVisible();
    }
    private void HealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        UpdateHealthbar();
        UpdateBarVisible();
    }
    private void HealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        UpdateHealthbar();
        UpdateBarVisible();
    }
    private void ConstructHealthBarSeparators()
    {

        Transform SeparatorTemplate = SeparatorContainer.Find("SeparatorTemplate");
        SeparatorTemplate.gameObject.SetActive(false);

        foreach (Transform SeparatorTransform in SeparatorContainer)
        {
            if (SeparatorTransform == SeparatorTemplate) continue;
            {
                Destroy(SeparatorTransform.gameObject);
            }
        }

        float HealthAmountPerSeparator = 10f;
        float barsize = 3f;
        float BarOneHealthAmountSize = (barsize / HealthSystem.GetHealthAmountMax());
        int HealthSeparatorCount = Mathf.FloorToInt(HealthSystem.GetHealthAmountMax() / HealthAmountPerSeparator);

        for (int i = 1; i < HealthSeparatorCount; i++)
        {
            Transform SeparatorTransform = Instantiate(SeparatorTemplate, SeparatorContainer);
            SeparatorTransform.gameObject.SetActive(true);
            SeparatorTransform.localPosition = new Vector3(BarOneHealthAmountSize * i * HealthAmountPerSeparator, 0, 0);
        }
    }

    private void HealthSystem_OnHealthAmountMaxChanged(object sender, System.EventArgs e)
    {
        ConstructHealthBarSeparators();
    }
    private void UpdateHealthbar()
    {
        BarTransform.localScale = new Vector3(HealthSystem.GetHealthAmountNormalised(), 1, 1);
    }

    private void UpdateBarVisible()
    {
        if (HealthSystem.IsFullHealth())
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}