using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDefender : MonoBehaviour {

    public Camera camera;
    private GameObject defendersParent;

    private void Start() {
        defendersParent = GameObject.Find("Defenders");
        if (defendersParent == null) {
            defendersParent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown() {
        GameObject newDefender = Instantiate(CustomButton.selectedDefender);
        newDefender.transform.parent = defendersParent.transform;
        newDefender.transform.position = MousePositionToWorldUnits();
        Debug.Log(newDefender.name + " positioned at " + newDefender.transform.position);
    }

    public Vector2 MousePositionToWorldUnits() {
        float mousex = Input.mousePosition.x;
        float mousey = Input.mousePosition.y;
        float distanceFromCamera = 10.0f;

        Vector3 AltTriplet = new Vector3(mousex, mousey, distanceFromCamera);
        Vector2 worldUnits = camera.ScreenToWorldPoint(AltTriplet);
        // Round numbers down to nearest integer
        worldUnits.x = Mathf.Floor(worldUnits.x += 0.5f);
        worldUnits.y = Mathf.Floor(worldUnits.y += 0.4f);

        return worldUnits;
    }
}
