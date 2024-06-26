﻿using UnityEngine;
using UnityEditor;

namespace Dust.DustEditor
{
    [CustomEditor(typeof(OnCollision2DEvent))]
    [CanEditMultipleObjects]
    public class OnCollision2DEventEditor : OnCollideEventEditor
    {
        [MenuItem("Dust/Events/On Collision 2D")]
        [MenuItem("GameObject/Dust/Events/On Collision 2D")]
        public static void AddComponent()
        {
            AddComponentToSelectedOrNewObject("DuCollision2D", typeof(OnCollision2DEvent));
        }
    }
}
