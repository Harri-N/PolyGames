using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

//Ce script permet de faire en sorte qu'un NPC se tourne vers le joueur durant un dialogue

public class NPCLookAt : MonoBehaviour
{
    [SerializeField] private Rig rig;
    [SerializeField] private Transform LookAtTransform;

    private bool isLookingAtPosition;

    private void Update() {
        float targetWeight = isLookingAtPosition ? 1f : 0f;
        float lerpSpeed = 2f;
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime * lerpSpeed);
    }

    public void LookAtPosition(Vector3 LookAtPosition) {
        isLookingAtPosition = true;
        LookAtTransform.position = LookAtPosition;
    }
}
