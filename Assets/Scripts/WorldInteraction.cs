using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

    public NavMeshAgent navMeshAgent;


    // Start is called before the first frame update
    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
            GetInteraction();
        }
    }

    void GetInteraction() {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(raycast, out RaycastHit hitInfo, Mathf.Infinity)) {
            Debug.DrawRay(transform.position, hitInfo.point, Color.red);
            GameObject interactedAtHit = hitInfo.collider.gameObject;
            navMeshAgent.updateRotation = true;

            if (!interactedAtHit.CompareTag("Interactable Object")) {
                navMeshAgent.destination = hitInfo.point;
                navMeshAgent.stoppingDistance = 0;
            }

        }
    }
}
