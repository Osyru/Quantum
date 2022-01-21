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
    public class SimpleButton : ButtonBase
    {
        /// <summary>
        /// Create a SimpleButton on a given UIPage
        /// </summary>
        /// <param name="buttonName">The text on the button</param>
        /// <param name="gameObjectName">The name of the GameObject</param>
        /// <param name="tooltip">The tooltip displayed at the bottom of the QuickMenu</param>
        /// <param name="icon">The icon of the button. Can be null to display no icon</param>
        /// <param name="parent">The parent GameObject to attach the button to</param>
        /// <param name="onClick">Action called when the button is pressed</param>
        public SimpleButton(string buttonName, string gameObjectName, string tooltip, Sprite icon, Transform parent, Action onClick) : base(buttonName, gameObjectName, tooltip, icon, parent)
        {
            BindingExtensions.Method_Public_Static_ButtonBindingHelper_Button_Action_0(buttonComponent, onClick);

            buttonGameObject.SetActive(true);
        }

        /// <summary>
        /// Create a SimpleButton on a given UIPage
        /// </summary>
        /// <param name="buttonName">The text on the button</param>
        /// <param name="gameObjectName">The name of the GameObject</param>
        /// <param name="tooltip">The tooltip displayed at the bottom of the QuickMenu</param>
        /// <param name="icon">The icon of the button. Can be null to display no icon</param>
        /// <param name="parent">The parent GameObject to attach the button to</param>
        /// <param name="onClick">Action called when the button is pressed</param>
        /// <param name="bigMenuPageIndex">The page to show when the BigMenu opens/param>
        public SimpleButton(string buttonName, string gameObjectName, string tooltip, Sprite icon, Transform parent, Action onClick, int bigMenuPageIndex) : base(buttonName, gameObjectName, tooltip, icon, parent)
        {
            buttonGameObject.transform.Find("Badge_MMJump").gameObject.SetActive(true);

            BindingExtensions.Method_Public_Static_ButtonBindingHelper_Button_Action_0(buttonComponent, onClick);

            buttonGameObject.SetActive(true);
        }
    }
}
