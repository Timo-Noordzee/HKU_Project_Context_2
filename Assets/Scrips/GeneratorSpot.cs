using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class GeneratorSpot: MonoBehaviour {

    public GeneratorSettingsProfile settingsProfile;

    private CapsuleCollider zoneTrigger;

    private void Start() {
        zoneTrigger = GetComponent<CapsuleCollider>();
        if (settingsProfile == null) {
            settingsProfile = SettingsProfile.Main.DefaultGeneratorSettingsProfile;
            Debug.LogWarning("GeneratorSpot doesn't have a SettingsProfile assigned the default is used instead!");
        }
    }

    private void OnValidate() {
        if (settingsProfile != null) {
            if (zoneTrigger == null) {
                zoneTrigger = GetComponent<CapsuleCollider>();
            }
            zoneTrigger.radius = settingsProfile.GeneratorDetectionRange;
            zoneTrigger.height = 3.0f;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        if (settingsProfile != null) {
            Gizmos.DrawWireSphere(transform.position, settingsProfile.GeneratorDetectionRange);
        }
    }

}
