// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;
using UnityEngine.UI;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Simple Behaviour which calculates the average frames per second over a number of frames and shows the FPS in a referenced Text control.
    /// </summary>
    [RequireComponent(typeof(TextMesh))]
    public class HeightDisplay : MonoBehaviour
    {
        [Tooltip("Reference to TextMesh component where the FPS should be displayed.")]
        [SerializeField]
        private TextMesh textMesh;

        [Tooltip("Reference to uGUI text component where the FPS should be displayed.")]
        [SerializeField]
        private Text uGUIText;

        private void Update()
        {
            if (textMesh == null)
            {
                InitBuffer();
            }

            UpdateTextDisplay();
        }

        private void InitBuffer()
        {
            if (textMesh == null)
            {
                textMesh = GetComponent<TextMesh>();
            }

            if (uGUIText == null)
            {
                uGUIText = GetComponent<Text>();
            }
        }

        private void UpdateTextDisplay()
        {
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.transform.position,
                                    new Vector3(0, -1, 0),
                                    out hitInfo,
                                    3f,
                                    SpatialMappingManager.Instance.LayerMask);
            var distance = Vector3.Distance(Camera.main.transform.position, hitInfo.point);
            string displayString = string.Format("Height: {0}", distance);

            if (textMesh != null)
            {
                textMesh.text = displayString;
            }

            if (uGUIText != null)
            {
                uGUIText.text = displayString;
            }
        }
    }
}