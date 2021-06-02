﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Difficulty Curves", menuName = "ScriptableObjects/Difficulty Curves")]
public class DifficultyCurvesScriptableObject : ScriptableObject
{
    [Tooltip("Delay between individual waves")]
    [SerializeField] private AnimationCurve _enemySpawnDelay = null;
    public AnimationCurve EnemySpawnDelay { get => _enemySpawnDelay; }

    [Tooltip("Number of enemies in a wave")]
    [SerializeField] private AnimationCurve _enemySpawnCount = null;
    public AnimationCurve EnemySpawnCount { get => _enemySpawnCount; }

    [Tooltip("Delay between groups of waves")]
    [SerializeField] private AnimationCurve _delayBetweenWaveGroups = null;
    public AnimationCurve DelayBetweenWaveGroups { get => _delayBetweenWaveGroups; }

    [Tooltip("Number of waves in a group")]
    [SerializeField] private AnimationCurve _wavesInGroup = null;
    public AnimationCurve WavesInGroup { get => _wavesInGroup; }
}

[CustomEditor(typeof(DifficultyCurvesScriptableObject))]
class DifficultyCurvesScriptableObjectEditor : Editor
{
    // Whether or not the help text should be shown
    private bool _showText = true;

    public override void OnInspectorGUI()
    {
        // Get reference to script
        PursueTargetBehaviour script = target as PursueTargetBehaviour;

        // Declare help text
        string helpText = "Curves should remain within a value and time of 0 - 1. Exceeding may cause undesired behavior.";

        // Display help text
        _showText = EditorGUILayout.BeginFoldoutHeaderGroup(_showText, "Info");
        if (_showText)
        {
            EditorGUILayout.HelpBox(helpText, MessageType.Warning);
        }

        EditorGUILayout.EndFoldoutHeaderGroup();

        // Display base inspector gui
        base.OnInspectorGUI();
    }
}