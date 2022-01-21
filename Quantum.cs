using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MelonLoader;

using UnityEngine;

using Quantum.API.UI;
using Quantum.API.UI.QuickMenu;

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
            UIManager.Init();

            LoggerInstance.Msg(ConsoleColor.DarkCyan, "Removing EmojiButton from QuickMenu...");

            GameObject _buttonEmoji = UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Emojis").gameObject;

            try
            {
                _buttonEmoji.SetActive(false);
            }
            catch (Exception ex) { LoggerInstance.Error("Couldn't disable EmojiButton from QuickMenu"); }

            LoggerInstance.Msg(ConsoleColor.DarkCyan, "Creating new button on QuickMenu UIPage Dashboard...");

            SubMenu _sm1 = new SubMenu("Quantum Main Menu", "QuantumMainMenu", true, UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").GetComponent<VRC.UI.Elements.Menus.LaunchPadQMMenu>());
            SubMenu _sm2 = new SubMenu("Quantum Settings", "QuantumSubMainSettings", true, UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").GetComponent<VRC.UI.Elements.Menus.LaunchPadQMMenu>());


            SimpleButton _b1 = new SimpleButton("Quantum", "QuantumMain", "Quantum Main Menu", null, UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions"), new Action(() => UIManager.OpenSubMenu(UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").GetComponent<VRC.UI.Elements.Menus.LaunchPadQMMenu>(), _sm1.uiPage)));
            SimpleButton _b2 = new SimpleButton("Settings", "QuantumSettings", "Quantum Settings", null, UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_QuantumMainMenu/ScrollRect/Viewport/VerticalLayoutGroup"), new Action(() => UIManager.OpenSubMenu(UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").GetComponent<VRC.UI.Elements.Menus.LaunchPadQMMenu>(), _sm2.uiPage)));
            SimpleButton _b3 = new SimpleButton("u gae", "ugae", "u big gae", null, UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_QuantumMainMenu/ScrollRect/Viewport/VerticalLayoutGroup"), new Action(() => LoggerInstance.Msg("why u so gae")));
            SimpleButton _b4 = new SimpleButton("another button", "anotherbutton", "idk anymore", null, UIManager.userInterface.transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_QuantumSubMainSettings/ScrollRect/Viewport/VerticalLayoutGroup"), new Action(() => LoggerInstance.Msg("i really don't know")));

        }
    }
}