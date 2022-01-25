using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

using VRC.UI.Elements;
using VRC.DataModel.Core;

namespace Quantum.API.UI.QuickMenu
{
    public static class Prefabs
    {
        private const string _emojiButtonPath = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Emojis";
        private const string _pinFPSPingPath = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug/Button_PinFPSAndPing";
        private const string _textH1Path = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug/Button_Build/Text_H1";
        private const string _iconOnPath = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug/Button_PinFPSAndPing/Icon_On";
        private const string _iconOffPath = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug/Button_PinFPSAndPing/Icon_Off";
        private const string _tabButtonPath = "";
        private const string _subMenuPath = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_QM_Emojis";

        public static GameObject SimpleButton { get; private set; }
        public static GameObject ToggleButton { get; private set; }
        public static GameObject MultichoiceButton { get; private set; }
        public static GameObject DisplayButton { get; private set; }
        public static GameObject TabButton { get; private set; }
        public static GameObject SubMenu { get; private set; }

        public static void CreatePrefabs()
        {
            CreateSimpleButtonPrefab();
            CreateToggleButtonPrefab();
            CreateMultichoiceButtonPrefab();
            CreateDisplayButtonPrefeb();

            CreateSubMenuPrefab();
        }

        private static void CreateSimpleButtonPrefab()
        {
            SimpleButton = GameObject.Instantiate(UIManager.UserInterfaceGO.transform.Find(_emojiButtonPath).gameObject, UIManager.UIPrefabsParentGO.transform);
            SimpleButton.name = "Quantum_SimpleButton_Prefab";

            var _tmpIcon = SimpleButton.transform.Find("Icon").gameObject;
            _tmpIcon.GetComponent<Image>().sprite = null;
            _tmpIcon.SetActive(false);

            var _tmpTextH1 = GameObject.Instantiate(UIManager.UserInterfaceGO.transform.Find(_textH1Path).gameObject, SimpleButton.transform);
            _tmpTextH1.name = UIManager.UserInterfaceGO.transform.Find(_textH1Path).gameObject.name;
            _tmpTextH1.SetActive(false);

            GameObject.DestroyImmediate(SimpleButton.GetComponent<BindingComponent>());

            SimpleButton.SetActive(false);
        }

        private static void CreateToggleButtonPrefab()
        {
            ToggleButton = GameObject.Instantiate(UIManager.UserInterfaceGO.transform.Find(_pinFPSPingPath).gameObject, UIManager.UIPrefabsParentGO.transform);
            ToggleButton.name = "Quantum_ToggleButton_Prefab";

            var _tmpIconOn = ToggleButton.transform.Find("Icon_On").gameObject;
            _tmpIconOn.GetComponent<Image>().sprite = null;
            _tmpIconOn.SetActive(false);
        }

        private static void CreateMultichoiceButtonPrefab()
        {

        }

        private static void CreateDisplayButtonPrefeb()
        {

        }

        private static void CreateSubMenuPrefab()
        {
            SubMenu = UIManager.UserInterfaceGO.transform.Find(_subMenuPath).gameObject;

            GameObject.DestroyImmediate(SubMenu.GetComponent<UIPage>());
            GameObject.DestroyImmediate(SubMenu.GetComponent<DashboardEmojiMenu>()); // Specific to this GameObject "Menu_QM_Emojis"

            foreach (Transform children in SubMenu.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup"))
                GameObject.DestroyImmediate(children.gameObject);
        }
    }
}
