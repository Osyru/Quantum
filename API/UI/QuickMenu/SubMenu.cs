using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

using VRC.UI.Elements;

namespace Quantum.API.UI.QuickMenu
{
    public class SubMenu
    {
        public GameObject subMenu;

        public TextMeshProUGUI tmpUGUI;

        public Button backButton;

        public UIPage uiPage;

        public SubMenu(string pageName, string gameObjectName, bool useBackButton, UIPage rootPage)
        {
            subMenu = GameObject.Instantiate(UIManager.Templates.subMenu, UIManager.qmParent.transform);

            subMenu.name = "Menu_" + gameObjectName;

            tmpUGUI = subMenu.transform.Find("Header_Emojis/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>();
            tmpUGUI.text = pageName;

            backButton = subMenu.transform.Find("Header_Emojis/LeftItemContainer/Button_Back").GetComponent<Button>();

            if (useBackButton)
            {
                backButton.onClick = new Button.ButtonClickedEvent();
                backButton.onClick.AddListener(new Action(() => UIManager.CloseSubMenu(rootPage)));
            }
            else
                backButton.gameObject.SetActive(false);

            uiPage = subMenu.AddComponent<UIPage>();
            uiPage.field_Public_String_0 = subMenu.name;
            uiPage.field_Private_MenuStateController_0 = UIManager.QMStateController;
            uiPage.field_Public_Boolean_0 = true;

            UIManager.QMStateController.field_Private_Dictionary_2_String_UIPage_0.Add(subMenu.name, uiPage);
        }
    }
}
