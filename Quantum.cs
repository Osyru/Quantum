using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MelonLoader;

using UnityEngine;

using Quantum.API.UI;
using Quantum.API.UI.QuickMenu;
using Quantum.Client;

[assembly: MelonInfo(typeof(Quantum.QMain), "Quantum", "0.0.0.0", "Osyru")]
[assembly: MelonGame("VRChat", "VRChat")]
//[assembly: VerifyLoaderVersion(0, 5, 2, true)] Doesn't work for some reason, maybe because tested on freedomloader
[assembly: MelonColor(ConsoleColor.Blue)]
[assembly: MelonPriority(42069)]

namespace Quantum
{
    public class QMain : MelonMod
    {
        internal static QMain Instance { get; private set; }

        public override void OnApplicationStart()
        {
            Instance = this;

            UIManager.OnUIManagerInitialized += OnUIManagerInitialized;

            UIManager.Init();
        }

        private void OnUIManagerInitialized()
        {
            UIManager.OnUIManagerInitialized -= OnUIManagerInitialized;

            QuantumClient.Init();
        }
    }
}