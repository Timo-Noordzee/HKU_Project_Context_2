using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameEventType {
    OnBuildGeneratorEvent
}

public static class EventManager {

    private static Dictionary<GameEventType, Action> events = new Dictionary<GameEventType, Action>();

    private static EventHandler eventHandler;

    public static void registerEventListener(GameEventType eventType, Action action) {
        if (!events.ContainsKey(eventType)) {
            events.Add(eventType, action);
        } else {
            events[eventType] += action;
        }
    }

    public static void unregisterEventListener(GameEventType eventType, Action action) {
        if (events.ContainsKey(eventType)) {
            events[eventType] -= action;
        }
    }

    public static void triggerEvent(GameEventType eventType) {
        if (events.ContainsKey(eventType)) {
            events[eventType]();
        }
    }

}
