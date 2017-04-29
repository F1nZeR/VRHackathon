// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
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
            var oxygenDisplayString = string.Format("Кислород: {0}%", Data.OxygenAmount);
            var burnString = string.Format("Ожоги: {0}%", Data.BurnsAmount);
            var displayString = oxygenDisplayString + Environment.NewLine + burnString;

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