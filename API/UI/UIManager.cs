using System;
using System.Reflection;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

using VRC.UI.Elements;
using VRC.DataModel.Core;

namespace Quantum.API.UI
{
    public delegate void UIManagerInitialized();

    public static class UIManager
    { 
        public static event UIManagerInitialized OnUIManagerInitialized;

        private const string _userInterfacePath = "UserInterface";
        private const string _quickMenuPath = "Canvas_QuickMenu(Clone)";
        private const string _qmParentPath = "Canvas_QuickMenu(Clone)/Container/Window/QMParent";

        public struct OpenUIPageInfo
        {
            public static readonly Type type = typeof(UIPage);
            public static readonly string startsWith = "Method_Public";
            public static readonly string[] doesntContain = { "_PDM" };
            public static readonly string[] calledMethods = { "Add", "Method_Private_UIPage_UIPage_0", "Method_Protected_Boolean_0" };

            public static MethodInfo method;
        }
        public struct CloseUIPageInfo
        {
            public static readonly Type type = typeof(UIPage);
            public static readonly string startsWith = "Method_Public";
            public static readonly string[] doesntContain = { "_PDM" };
            public static readonly string[] calledMethods = { "Method_Protected_Boolean_0", "Method_Private_UIPage_UIPage_0", "Method_Public_Void_Boolean_TransitionType_0" };

            public static MethodInfo method;
        }

        public static GameObject UIPrefabsParentGO { get; private set; }
        public static GameObject UserInterfaceGO { get; private set; }
        public static GameObject QuickMenuGO { get; private set; }
        public static GameObject QMParentGO { get; private set; }
        public static MenuStateController QMStateController { get; private set; }
        public static bool Initialized { get; private set; }

        public static void Init()
        {

            OpenUIPageInfo.method = Helpers.XrefUtils.GetMethod(OpenUIPageInfo.type, OpenUIPageInfo.startsWith, OpenUIPageInfo.doesntContain, OpenUIPageInfo.calledMethods);
            CloseUIPageInfo.method = Helpers.XrefUtils.GetMethod(CloseUIPageInfo.type, CloseUIPageInfo.startsWith, CloseUIPageInfo.doesntContain, CloseUIPageInfo.calledMethods);


            MelonLoader.MelonCoroutines.Start(WaitForUI());
        }

        private static IEnumerator WaitForUI()
        {
            bool _UIFound = false;

            while (!_UIFound)
            {
                yield return new WaitForSeconds(.1f);

                try
                {
                    GameObject.Find("UserInterface").transform.Find(_quickMenuPath);

                    _UIFound = true;
                }
                catch (Exception) { }
            }

            InitUI();
        }

        private static void InitUI()
        {
            UserInterfaceGO = GameObject.Find(_userInterfacePath);
            QuickMenuGO = UserInterfaceGO.transform.Find(_quickMenuPath).gameObject;
            QMParentGO = UserInterfaceGO.transform.Find(_qmParentPath).gameObject;
            QMStateController = QuickMenuGO.GetComponent<MenuStateController>();

            UIPrefabsParentGO = new GameObject("QuantumUIPrefabsParent");
            GameObject.DontDestroyOnLoad(UIPrefabsParentGO);

            QuickMenu.Prefabs.CreatePrefabs();

            OnUIManagerInitialized();
        }

        public static void OpenSubMenu(UIPage rootPage, UIPage uiPage)
        {
            OpenUIPageInfo.method.Invoke(rootPage, new object[] { uiPage, UIPage.TransitionType.Right });
        }

        public static void CloseSubMenu(UIPage rootPage)
        {
            CloseUIPageInfo.method.Invoke(rootPage, new object[] { rootPage.field_Private_List_1_UIPage_0[rootPage.field_Private_List_1_UIPage_0.Count - 1] });
        }
    }
}
