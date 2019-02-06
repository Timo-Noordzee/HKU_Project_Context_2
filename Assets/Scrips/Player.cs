using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour {

    public GeneratorSpot closestGenerator;

    public Image distanceIndicatorImage;
    public Image buildIndicatorImage;

    private bool returnToBase = false;

    private bool canBuild = false;
    private bool CanBuild {
        get { return canBuild; }
        set {
            if (canBuild == value) return;
            canBuild = value;
            if (canBuild) { buildIndicatorImage.GetComponent<Animation>().Play(); }
        }
    }

    private void Start() {

    }

    private void OnEnable() {
        EventManager.registerEventListener(GameEventType.OnBuildGeneratorEvent, OnBuildGenerator);
    }

    private void OnDisable() {
        EventManager.unregisterEventListener(GameEventType.OnBuildGeneratorEvent, OnBuildGenerator);
    }

    private void Update() {
        if (closestGenerator != null) {
            if (!returnToBase) {
                float distance = closestGenerator.CalculateDistance(transform.position, true);
                distanceIndicatorImage.fillAmount = distance;
                CanBuild = (distance >= 0.9f);
            } else {

                // TODO show a message that the user need to return to base

            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag(GeneratorSpot.TAG)) {
            closestGenerator = other.gameObject.GetComponent<GeneratorSpot>();
        } else if (other.gameObject.CompareTag(Base.TAG)) {
            returnToBase = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag(GeneratorSpot.TAG)) {
            closestGenerator = null;
        }
    }

    private void OnBuildGenerator() {
        returnToBase = true;
    }

}
