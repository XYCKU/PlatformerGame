using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpScript : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
        UpdateText();
    }

    private void OnEnable()
    {
        _healthSystem.OnHpChange += UpdateText;
    }

    private void OnDisable()
    {
        _healthSystem.OnHpChange -= UpdateText;
    }

    private void UpdateText()
    {
        _text.text = _healthSystem.Health.ToString() + "/" + _healthSystem.MaxHealth;
    }
}
