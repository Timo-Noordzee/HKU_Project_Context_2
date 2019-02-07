using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Astroid Settings Profile")]
public class AstroidSettingsProfile: ScriptableObject {

    [Tooltip("The delay between individual astroids")]
    [SerializeField] private float astroidIntervalDelay = 5.0f;
    public float AstroidIntervalDelay {
        get { return astroidIntervalDelay; }
    }

    [Tooltip("The radius arround the player when astroid are likely to hit")]
    [SerializeField] private float astroidPlayerZoneRange = 10.0f;
    public float AstroidPlayerZoneRange {
        get { return astroidPlayerZoneRange; }
    }

    [Tooltip("The chance an astroid hits within the player zone")]
    [SerializeField] private float astroidPlayerZoneChance = 0.5f;
    public float AstroidPlayerZoneChance {
        get { return astroidPlayerZoneChance; }
    }

    [Tooltip("The speed at which astroid fall form the sky")]
    [SerializeField] private float astroidMovementSpeed = 20.0f;
    public float AstroidMovementSpeed {
        get { return astroidMovementSpeed; }
    }

    [Tooltip("The range of astroid scales (x=min, y=max)")]
    [SerializeField] private Vector2 astroidScales = new Vector2(1, 4);
    public Vector2 AstroidScales {
        get { return astroidScales; }
    }

    [Tooltip("The threshold (minimum size) an astroid needs in order to survive a crash")]

    [Header("References")]
    public GameObject AstroidPrefab;

    public bool getAstroidPlayerZoneBool() {
        return Random.value >= AstroidPlayerZoneChance;
    }


}
