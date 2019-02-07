using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner: MonoBehaviour {

    private AstroidSettingsProfile settingsProfile;

    private bool spawnAstroids = true;
    private Coroutine spawnLoopCoroutine;
    private Vector3 target;

    private void Start() {
        settingsProfile = SettingsProfile.Main.AstroidSettingsProfile;
        spawnLoopCoroutine = StartCoroutine(IEAstroidSpawnLoop());
    }

    private IEnumerator IEAstroidSpawnLoop() {
        while (spawnAstroids) {
            yield return new WaitForSeconds(settingsProfile.AstroidIntervalDelay);
            SpawnAstroid(settingsProfile.getAstroidPlayerZoneBool());
        }
    }

    private void SpawnAstroid(bool inPlayerZone = false) {
        GameObject astroid = Instantiate(settingsProfile.AstroidPrefab, transform.position, Quaternion.identity, transform);
        Rigidbody rigidBody = astroid.GetComponent<Rigidbody>();

        if (inPlayerZone) {
            target = Player.Transform.position + Random.insideUnitSphere * settingsProfile.AstroidPlayerZoneRange;
        } else {
            target = Vector3.zero;
        }

        rigidBody.velocity = (target - transform.position).normalized * settingsProfile.AstroidMovementSpeed;

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if (target != null) {
            Gizmos.DrawSphere(target, 1);
        }
    }

}
