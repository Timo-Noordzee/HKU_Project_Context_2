﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/GeneratorSettingsProfile")]
public class GeneratorSettingsProfile: ScriptableObject {

    [Header("Generator Settings Profile")]

    [Tooltip("The minimum radius for the player in order to build a generator on the location")]
    [SerializeField] private float generatorPlacementRange = 5.0f;
    public float GeneratorPlacementRange {
        get { return generatorPlacementRange; }
    }

    [Tooltip("The minimum radius for the player to start receiving signals")]
    [SerializeField] private float generatorDetectionRange = 15.0f;
    public float GeneratorDetectionRange {
        get { return generatorDetectionRange; }
    }

}