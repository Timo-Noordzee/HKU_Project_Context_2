using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {

    #region SettingsProfile
    public SettingsProfile settingsProfile;
    public static SettingsProfile SettingsProfile {
        get { return Instance.settingsProfile; }
    }
    #endregion

    public static GameManager Instance;

    private void Awake() {
        Instance = this;
    }
}
