using _GAME.Code.Logic.Env.Markers;
using UnityEditor;
using UnityEngine;

namespace _GAME.Code.Editor
{
    [CustomEditor(typeof(MarkerSphere))]
    public class MarkerSphereEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(MarkerSphere spawner, GizmoType gizmo)
        {
            Gizmos.color = spawner.Color;
            Gizmos.DrawSphere(spawner.transform.position, spawner.Range);
        }
    }
}