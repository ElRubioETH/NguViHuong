using UnityEngine;
using Fusion;
using TMPro;
using System;

public class PlayPropotiy : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(OnHealthChanged))]
    public float health { get; set; }
    public float maxhealth { get; set; }
    public TextMeshProUGUI healthText;
    public void OnHealthChanged()
    {
        healthText.text = $"{health}/{maxhealth}";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
        }
    }
    private void Start()
    {
        maxhealth = 100;
        health = maxhealth;
        healthText.text = $"{health}/{maxhealth}";

    }
}
