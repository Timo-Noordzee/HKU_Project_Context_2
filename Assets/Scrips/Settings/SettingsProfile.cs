using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Settings Profile")]
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

    [Header("User Interface Settings")]
    [Tooltip("The default UserInterfaceSettingsProfile that gets assigned")]
    [SerializeField] private UserInterfaceSettingsProfile userInterfaceSettingsProfile;
    public UserInterfaceSettingsProfile UserInterfaceSettingsProfile {
        get { return userInterfaceSettingsProfile; }
    }

    [Header("Astroid Spawner Settings")]
    [SerializeField] AstroidSettingsProfile astroidSettingsProfile;
    public AstroidSettingsProfile AstroidSettingsProfile {
        get { return astroidSettingsProfile; }
    }

}

