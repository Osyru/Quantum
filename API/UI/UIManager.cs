using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using VRC.UI.Elements;
using VRC.DataModel.Core;

namespace Quantum.API.UI
{
    public static class UIManager
    {
        private const string _userInterfacePath = "UserInterface";
        private const string _quickMenuPath = "Canvas_QuickMenu(Clone)";
        private const string _qmParentPath = "Canvas_QuickMenu(Clone)/Container/Window/QMParent";

        private static MethodInfo _openPage;
        private static MethodInfo _closePage;

        public static GameObject userInterface;
        public static GameObject quickMenu;
        public static GameObject qmParent;
        public static MenuStateController QMStateController;

        public static class Templates
        {
            private const string _simpleButtonPath = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Emojis";
            private const string _toggleButtonPath = "";
            private const string _tabButtonPath = "";
            private const string _subMenuPath = "Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_QM_Emojis";

            public static GameObject simpleButton { get; private set; }
            public static GameObject toggleButton { get; private set; }
            public static GameObject tabButton { get; private set; }
            public static GameObject subMenu { get; private set; }

            public static void Init()
            {
                QMain.Instance.LoggerInstance.Msg(ConsoleColor.DarkCyan, "Loading UI templates...");

                SetSimpleButton();
                SetSubMenu();
            }

            private static void SetSimpleButton()
            {
                QMain.Instance.LoggerInstance.Msg("Getting SimpleButton...");

                try
                {
                    simpleButton = userInterface.transform.Find(_simpleButtonPath).gameObject;

                    GameObject.DestroyImmediate(simpleButton.GetComponent<BindingComponent>());
                }
                catch (Exception ex) { QMain.Instance.LoggerInstance.Error("Couldn't set SimpleButton template."); }
            }

            private static void SetSubMenu()
            {
                QMain.Instance.LoggerInstance.Msg("Getting SubMenu...");

                try
                {
                    subMenu = userInterface.transform.Find(_subMenuPath).gameObject;

                    GameObject.DestroyImmediate(subMenu.GetComponent<UIPage>());
                    GameObject.DestroyImmediate(subMenu.GetComponent<DashboardEmojiMenu>()); // Specific to this GameObject "Menu_QM_Emojis"

                    foreach (Transform children in subMenu.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup"))
                        GameObject.DestroyImmediate(children.gameObject);
                }
                catch (Exception ex) { QMain.Instance.LoggerInstance.Error("Couldn't set SubMenu template."); }
            }
        }

        public static void Init()
        {
            _openPage = typeof(UIPage).GetMethod("Method_Public_Void_UIPage_TransitionType_0"); // Make a proper Xref
            _closePage = typeof(UIPage).GetMethod("Method_Public_Void_UIPage_0"); // Make a proper Xref

            InitUI();
        }

        private static void InitUI()
        {
            QMain.Instance.LoggerInstance.Msg(ConsoleColor.DarkCyan, "Initializing UI...");

            try
            {
                userInterface = GameObject.Find(_userInterfacePath);

            }
            catch (Exception ex) { QMain.Instance.LoggerInstance.Error("Couldn't find \"UserInterface\" GameObject"); }

            try
            {
                quickMenu = userInterface.transform.Find(_quickMenuPath).gameObject;

            }
            catch (Exception ex) { QMain.Instance.LoggerInstance.Error("Couldn't find \"Canvas_QuickMenu(Clone)\" GameObject"); }

            try
            {
                qmParent = userInterface.transform.Find(_qmParentPath).gameObject;

            }
            catch (Exception ex) { QMain.Instance.LoggerInstance.Error("Couldn't find \"QMParent\" GameObject"); }

            try
            {
                QMStateController = quickMenu.GetComponent<MenuStateController>();
            }
            catch (Exception ex) { QMain.Instance.LoggerInstance.Error("Couldn't find \"MenuStateController\" component on \"Canvas_QuickMenu(Clone)\" GameObject"); }

            Templates.Init();
        }

        public static void OpenSubMenu(UIPage rootPage, UIPage uiPage)
        {
            _openPage.Invoke(rootPage, new object[] { uiPage, UIPage.TransitionType.Right });
        }

        public static void CloseSubMenu(UIPage rootPage)
        {
            _closePage.Invoke(rootPage, new object[] { rootPage.field_Private_List_1_UIPage_0[rootPage.field_Private_List_1_UIPage_0.Count - 1] });
        }


        // get a template for QuickMenu:
        // - simple button
        // - toggle button
        // - tab button
        // - dropdown button
        // - multichoice button (settings menu "UI elements")
        // - slider
        // - button that isn't a button just to display text (settings menu "FPS")
        // - UI Page
        // - TabMenu page
        // - Wings
        // - Wing Button

    }
}
