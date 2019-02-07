using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/UI Settings Profile")]
public class UserInterfaceSettingsProfile: ScriptableObject {

    [Header("Icons")]
    public Sprite iconBuild;
    public Sprite iconHome;

    [Header("Colors")]
    [SerializeField] private Gradient heathIndicatorGradient;
    public Gradient HeathIndicatorGradient {
        get { return heathIndicatorGradient; }
    }

}
