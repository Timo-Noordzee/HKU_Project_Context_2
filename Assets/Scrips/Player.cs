using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour {

    public GeneratorSpot closestGenerator;

    public Image distanceIndicatorImage;
    public Animator animator;

    public GameObject generatorPrefab;

    private bool returnToBase = false;

    private bool canBuild = false;
    private bool CanBuild {
        get { return canBuild; }
        set {
            if (canBuild == value) return;
            canBuild = value;
            if (canBuild && !returnToBase) {
                UserInterfaceManager.UpdateTooltipIcon(Icon.Build);
                UserInterfaceManager.ShowTooltip("Keep pressing left click to build generator!");
                UserInterfaceManager.ToggleTooltipIcon(true);
            }
        }
    }
    private bool isBuilding;

    private SettingsProfile settingsProfile;

    private static Player Instance;
    public static Transform Transform {
        get { return Instance.transform; }
    }

    private void Start() {
        settingsProfile = SettingsProfile.Main;
        Instance = this;
    }

    private void OnEnable() {
        EventManager.registerEventListener(GameEventType.OnBuildGeneratorEvent, OnBuildGenerator);
    }

    private void OnDisable() {
        EventManager.unregisterEventListener(GameEventType.OnBuildGeneratorEvent, OnBuildGenerator);
    }

    private void Update() {
        if (closestGenerator != null) {
            float distance = closestGenerator.CalculateDistance(transform.position, true);
            distanceIndicatorImage.color = settingsProfile.UserInterfaceSettingsProfile.HeathIndicatorGradient.Evaluate(distance);
            CanBuild = (distance >= 1) && !closestGenerator.isbuild;
        }

        if (Input.GetButtonDown("Fire1")) {
            if (CanBuild && !returnToBase) {
                closestGenerator.AddBuildingProgress(0.1f);
            }
        }
    }

    private IEnumerator IEBuildGenerator() {
        float buildDuration = settingsProfile.GeneratorSettingsProfile.GeneratorBuildingDuration;
        float steps = buildDuration / 0.1f;
        for (int i = 0; i < steps; i++) {
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag(GeneratorSpot.TAG)) {
            closestGenerator = other.gameObject.GetComponent<GeneratorSpot>();
        } else if (other.gameObject.CompareTag(Base.TAG)) {
            if (returnToBase) {
                UserInterfaceManager.ToggleTooltipIcon(false);
                UserInterfaceManager.ToggleTooltip(false);
            }
            returnToBase = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag(GeneratorSpot.TAG)) {
            closestGenerator = null;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Lava")) {
            EventManager.triggerEvent(GameEventType.PlayerDieEvent);
        }
    }

    private void OnBuildGenerator() {
        returnToBase = true;
        canBuild = false;

        closestGenerator.isbuild = true;
        Instantiate(generatorPrefab, closestGenerator.transform.position, closestGenerator.transform.rotation, closestGenerator.transform);


        UserInterfaceManager.UpdateTooltipIcon(Icon.Home);
        UserInterfaceManager.ShowTooltip("Return to the main base to restock on supplies!");
    }

}
