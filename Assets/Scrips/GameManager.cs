using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {

    public SettingsProfile settingsProfile;
    public static SettingsProfile SettingsProfile {
        get { return Instance.settingsProfile; }
    }

    public static GameManager Instance;

    [HideInInspector] Player player;

    private void Awake() {
        Instance = this;
    }
}
