using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEditor.SceneManagement;

public static class BuildScene
{
    [MenuItem("Tools/Crear escena VR")]
    static void Build()
    {
        // Piso
        var plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.name = "Piso";
        plane.transform.position = Vector3.zero;

        // Cubo agarrable
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "Cubo";
        cube.transform.position = new Vector3(0f, 1f, 0.5f);
        cube.transform.localScale = Vector3.one * 0.15f;

        var rb = cube.AddComponent<Rigidbody>();
        rb.mass = 0.5f;

        var grab = cube.AddComponent<XRGrabInteractable>();
        grab.movementType = XRBaseInteractable.MovementType.VelocityTracking;
        grab.throwOnDetach = true;
        grab.throwVelocityScale = 1.5f;
        grab.throwAngularVelocityScale = 1.5f;

        // Regresar el cubo si se cae
        cube.AddComponent<CubeRespawn>();

        // Borrar Main Camera si existe
        var cam = GameObject.Find("Main Camera");
        if (cam != null) Object.DestroyImmediate(cam);

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        Debug.Log("Escena VR creada.");
    }
}