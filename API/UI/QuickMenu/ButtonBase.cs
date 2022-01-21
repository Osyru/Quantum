using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

using VRC.DataModel.Core;

namespace Quantum.API.UI.QuickMenu
{
    public class ButtonBase
    {
        /// <summary>
        /// The GameObject of the button
        /// </summary>
        public GameObject buttonGameObject;

        /// <summary>
        /// The Button Component on the button GameObject
        /// </summary>
        public Button buttonComponent;

        /// <summary>
        /// The TextMeshPro component on the button GameObject
        /// </summary>
        public TextMeshProUGUI tmpUGUI;

        /// <summary>
        /// The UiTooltip component on the the button GameObject
        /// </summary>
        public VRC.UI.Elements.Tooltips.UiTooltip buttonTooltip;

        /// <summary>
        /// The Image component on the the button GameObject
        /// </summary>
        public Image imageComponent;


        /// <summary>
        /// Creates the base of a button
        /// </summary>
        /// <param name="buttonName">The text on the button</param>
        /// <param name="gameObjectName">The name of the GameObject</param>
        /// <param name="tooltip">The tooltip displayed at the bottom of the QuickMenu</param>
        /// <param name="icon">The icon/image shown on the button</param>
        /// <param name="parent">The parent GameObject to attach the button to</param>
        public ButtonBase(string buttonName, string gameObjectName, string tooltip, Sprite icon, Transform parent)
        {
            buttonGameObject = GameObject.Instantiate(UIManager.Templates.button, parent);

            buttonGameObject.name = "Button_" + gameObjectName;

            tmpUGUI = buttonGameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
            tmpUGUI.text = buttonName;

            buttonTooltip = buttonGameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
            buttonTooltip.field_Public_String_0 = tooltip;

            if (buttonGameObject.transform.Find("Icon") == null)
                imageComponent = buttonGameObject.transform.Find("Icon_On").GetComponent<Image>();
            else
                imageComponent = buttonGameObject.transform.Find("Icon").GetComponent<Image>();

            if (icon != null)
                imageComponent.sprite = icon;

            buttonComponent = buttonGameObject.GetComponent<Button>();
        }
    }
}
