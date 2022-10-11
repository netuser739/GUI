using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] public int _health = 100;

    public int Health => _health;
}
