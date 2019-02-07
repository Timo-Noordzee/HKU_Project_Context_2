using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserInterfaceManager: MonoBehaviour {

    [Header("References")]
    public Image tooltipIcon;
    public Text tooltip;

    private UserInterfaceSettingsProfile settingsProfile;

    private Animator tooltipIconAnimator;
    private Animator tooltipAnimator;

    private Coroutine tooltipCoroutine;

    private static UserInterfaceManager Instance;


    private void Awake() {
        Instance = this;
    }

    private void Start() {
        settingsProfile = SettingsProfile.Main.UserInterfaceSettingsProfile;

        tooltipIconAnimator = tooltipIcon.GetComponent<Animator>();
        tooltipAnimator = tooltip.GetComponent<Animator>();
    }

    public static void UpdateTooltipIcon(Icon icon) {
        switch (icon) {
            case Icon.Build:
                Instance.tooltipIcon.sprite = Instance.settingsProfile.iconBuild;
                break;
            case Icon.Home:
                Instance.tooltipIcon.sprite = Instance.settingsProfile.iconHome;
                break;
        }
    }

    public static void ShowTooltip(string message) {
        Instance.tooltip.text = message;
        if (Instance.tooltipCoroutine != null) {
            Instance.StopCoroutine(Instance.tooltipCoroutine);
        }
        ToggleTooltip(true);
    }

    public static void ShowTooltip(string message, float duration) {
        Instance.tooltip.text = message;
        if (Instance.tooltipCoroutine != null) {
            Instance.StopCoroutine(Instance.tooltipCoroutine);
            ToggleTooltip(false);
        }
        Instance.tooltipCoroutine = Instance.StartCoroutine(IEShowTooltip(message, duration));

    }

    public static void ToggleTooltipIcon(bool show) {
        Instance.tooltipIconAnimator.SetBool("Show", show);
        Instance.tooltipIconAnimator.SetTrigger("ShowIcon");
    }

    public static void ToggleTooltip(bool show) {
        Instance.tooltipAnimator.SetBool("Show", show);
        Instance.tooltipAnimator.SetTrigger("ShowTrigger");
    }

    private static IEnumerator IEShowTooltip(string message, float duration) {
        ToggleTooltip(true);
        yield return new WaitForSeconds(duration);
        ToggleTooltip(false);
    }

}

public enum Icon {
    Build,
    Home
}
