using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MelonLoader;

using UnityEngine;

[assembly: MelonInfo(typeof(Quantum.QMain), "Quantum", "0.0.1", "Osyru")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonColor(ConsoleColor.DarkMagenta)]
[assembly: MelonPriority(42069)]

namespace Quantum
{
    public class QMain : MelonMod
    {
        internal static QMain Instance { get; private set; }

        public override void OnApplicationStart()
        {
            Instance = this;
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Testing();
            }
        }

        public void Testing()
        {
            API.UI.UIManager.Init();

            LoggerInstance.Msg(ConsoleColor.DarkCyan, "Removing EmojiButton from QuickMenu...");

            GameObject _buttonEmoji = API.UI.UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Emojis").gameObject;

            try
            {
                _buttonEmoji.SetActive(false);
            }
            catch (Exception ex) { LoggerInstance.Error("Couldn't disable EmojiButton from QuickMenu"); }

            LoggerInstance.Msg(ConsoleColor.DarkCyan, "Creating new button on QuickMenu UIPage Dashboard...");

            API.UI.QuickMenu.SubMenu _sm1 = new API.UI.QuickMenu.SubMenu("Quantum Main Menu", "QuantumMainMenu", true, API.UI.UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").GetComponent<VRC.UI.Elements.Menus.LaunchPadQMMenu>());
            API.UI.QuickMenu.SubMenu _sm2 = new API.UI.QuickMenu.SubMenu("Quantum Settings", "QuantumSubMainSettings", true, API.UI.UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").GetComponent<VRC.UI.Elements.Menus.LaunchPadQMMenu>());


            API.UI.QuickMenu.SimpleButton _b1 = new API.UI.QuickMenu.SimpleButton("Quantum", "QuantumMain", "Quantum Main Menu", null, API.UI.UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions"), new Action(() => API.UI.UIManager.OpenSubMenu(API.UI.UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").GetComponent<VRC.UI.Elements.Menus.LaunchPadQMMenu>(), _sm1.uiPage)));
            API.UI.QuickMenu.SimpleButton _b2 = new API.UI.QuickMenu.SimpleButton("Settings", "QuantumSettings", "Quantum Settings", null, API.UI.UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_QuantumMainMenu/ScrollRect/Viewport/VerticalLayoutGroup"), new Action(() => API.UI.UIManager.OpenSubMenu(API.UI.UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").GetComponent<VRC.UI.Elements.Menus.LaunchPadQMMenu>(), _sm2.uiPage)));
            API.UI.QuickMenu.SimpleButton _b3 = new API.UI.QuickMenu.SimpleButton("u gae", "ugae", "u big gae", null, API.UI.UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_QuantumMainMenu/ScrollRect/Viewport/VerticalLayoutGroup"), new Action(() => LoggerInstance.Msg("why u so gae")));
            API.UI.QuickMenu.SimpleButton _b4 = new API.UI.QuickMenu.SimpleButton("another button", "anotherbutton", "idk anymore", null, API.UI.UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_QuantumSubMainSettings/ScrollRect/Viewport/VerticalLayoutGroup"), new Action(() => LoggerInstance.Msg("i really don't know")));

        }
    }
}