﻿using UnityEngine;
using UnityEditor;

namespace Dust.DustEditor
{
    [CustomEditor(typeof(OnTrigger2DEvent))]
    [CanEditMultipleObjects]
    public class OnTrigger2DEventEditor : OnCollideEventEditor
    {
        [MenuItem("Dust/Events/On Trigger 2D")]
        [MenuItem("GameObject/Dust/Events/On Trigger 2D")]
        public static void AddComponent()
        {
            AddComponentToSelectedOrNewObject("DuTrigger2D", typeof(OnTrigger2DEvent));
        }
    }
}
