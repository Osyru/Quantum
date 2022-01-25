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
        public GameObject gameObject;

        /// <summary>
        /// The Button Component on the button GameObject
        /// </summary>
        public Button button;

        /// <summary>
        /// The TextMeshPro component on the button GameObject "Text_H4", which is the bottom text
        /// </summary>
        public TextMeshProUGUI textH4;

        /// <summary>
        /// The TextMeshPro component on the button GameObject "Text_H1", which is the middle text
        /// </summary>
        public TextMeshProUGUI textH1;

        /// <summary>
        /// The UiTooltip component on the the button GameObject
        /// </summary>
        public VRC.UI.Elements.Tooltips.UiTooltip simpleTooltip;

        /// <summary>
        /// The Image component on the the button GameObject
        /// </summary>
        public Image imageComponent;

        public Image icon;

        public Image iconOn;

        public Image iconOff;

        public VRC.UI.Elements.Tooltips.UiToggleTooltip toggleTooltip;

        public Toggle toggle;

        public VRC.UI.Elements.Controls.ToggleIcon toggleIcon;

        public enum ButtonType
        {
            SimpleButton = 1,
            ToggleButton = 2,
            MultichoiceButton = 3,
            DisplayButton = 4
        }

        public ButtonBase(ButtonType pType, string pGameObjectName, Transform pParent)
        {
            switch(pType)
            {
                case ButtonType.SimpleButton:
                    SimpleButton(pParent);
                    break;
                case ButtonType.ToggleButton:
                    ToggleButton(pParent);
                    break;
                case ButtonType.MultichoiceButton:
                    MultichoiceButton(pParent);
                    break;
                case ButtonType.DisplayButton:
                    DisplayButton(pParent);
                    break;
                default:
                    break;
            }

            gameObject.name = "Quantum_Button_" + String.Concat(pGameObjectName.Where(c => !Char.IsWhiteSpace(c)));
        }

        private void SimpleButton(Transform pParent)
        {
            gameObject = GameObject.Instantiate(Prefabs.SimpleButton, pParent);

            button = gameObject.GetComponent<Button>();

            textH4 = gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
            textH1 = gameObject.transform.Find("Text_H1").GetComponent<TextMeshProUGUI>();

            icon = gameObject.transform.Find("Icon").GetComponent<Image>();

            simpleTooltip = gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
        }

        private void ToggleButton(Transform pParent)
        {
            gameObject = GameObject.Instantiate(Prefabs.ToggleButton, pParent);

            toggle = gameObject.GetComponent<Toggle>();

            textH4 = gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();

            iconOn = gameObject.transform.Find("Icon_On").GetComponent<Image>();
            iconOff = gameObject.transform.Find("Icon_Off").GetComponent<Image>();

            toggleTooltip = gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiToggleTooltip>();

            toggleIcon = gameObject.GetComponent<VRC.UI.Elements.Controls.ToggleIcon>();
        }

        private void MultichoiceButton(Transform pParent)
        {
            gameObject = GameObject.Instantiate(Prefabs.MultichoiceButton, pParent);

            textH4 = gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
        }

        private void DisplayButton(Transform pParent)
        {
            gameObject = GameObject.Instantiate(Prefabs.DisplayButton, pParent);

            textH4 = gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
            textH1 = gameObject.transform.Find("Text_H1").GetComponent<TextMeshProUGUI>();

            simpleTooltip = gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
        }
    }
}
