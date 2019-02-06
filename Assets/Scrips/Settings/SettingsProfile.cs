using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/SettingsProfile")]
public class SettingsProfile: ScriptableObject {

    public static SettingsProfile Main {
        get { return GameManager.SettingsProfile; }
    }

    [Header("Generator Settings")]
    [Tooltip("The default GeneratorSettingsProfile that gets assigned if the generator doesn't have a custom profile")]
    [SerializeField] private GeneratorSettingsProfile generatorSettingsProfile;
    public GeneratorSettingsProfile GeneratorSettingsProfile {
        get { return generatorSettingsProfile; }
    }

}

