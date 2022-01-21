using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

using VRC.UI.Elements;
using VRC.DataModel.Core;

namespace Quantum.API.UI.QuickMenu
{
    public class SimpleButton
    {
        public GameObject simpleButton;

        public TextMeshProUGUI tmpUGUI;

        public VRC.UI.Elements.Tooltips.UiTooltip buttonTooltip;

        public Button button;

        /// <summary>
        /// Create a SimpleButton on a given UIPage
        /// </summary>
        /// <param name="name">The text of the button</param>
        /// <param name="tooltip">The tooltip displayed at the bottom of the QuickMenu</param>
        /// <param name="icon">The icon of the button. Can be null to display no icon</param>
        /// <param name="parent">The UIPage to attach the button to</param>
        /// <param name="onClick">Action called when the button is pressed</param>
        public SimpleButton(string buttonName, string gameObjectName, string tooltip, object icon, Transform parent, Action onClick)
        {
            simpleButton = GameObject.Instantiate(UIManager.Templates.simpleButton, parent);

            simpleButton.name = "Button_" + gameObjectName;

            tmpUGUI = simpleButton.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
            tmpUGUI.text = buttonName;

            buttonTooltip = simpleButton.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
            buttonTooltip.field_Public_String_0 = tooltip;

            if (icon == null)
                simpleButton.transform.Find("Icon").gameObject.SetActive(false);

            button = simpleButton.GetComponent<Button>();
            BindingExtensions.Method_Public_Static_ButtonBindingHelper_Button_Action_0(button, onClick);

            simpleButton.SetActive(true);
        }
    }
}
