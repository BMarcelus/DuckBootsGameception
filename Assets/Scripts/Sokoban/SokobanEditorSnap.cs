#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class SokobanEditorSnap : MonoBehaviour {
    Vector3 lastPos;

    void Update() {
        if(EditorApplication.isPlaying ) return;

        if (transform.localPosition != lastPos) {
            transform.localPosition = new Vector3(
                Mathf.Round(transform.localPosition.x) / SokobanController.gridUnitSize,
                Mathf.Round(transform.localPosition.y) / SokobanController.gridUnitSize,
                transform.localPosition.z);
            lastPos = transform.localPosition;
        }
    }
}
#endif
