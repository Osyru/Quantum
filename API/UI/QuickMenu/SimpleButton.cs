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
        public SimpleButton(string pText, string pTooltip, Sprite pIcon, Transform pParent, Action pOnClick) : base(ButtonType.SimpleButton, pText, pParent)
        {
            if (pIcon == null)
            {
                textH1.text = pText;
                textH1.enableAutoSizing = true;

                textH1.color = new Color(0.2980392f, 0.5568628f, 0.5843138f, 1f); // set the h1 text to color of h4 text

                textH1.gameObject.SetActive(true);
                textH4.gameObject.SetActive(false);
            }
            else
            {
                textH4.text = pText;
            }

            simpleTooltip.field_Public_String_0 = pTooltip;

            BindingExtensions.Method_Public_Static_ButtonBindingHelper_Button_Action_0(button, pOnClick);

            gameObject.SetActive(true);
        }
    }
}
