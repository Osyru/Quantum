using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib.XrefScans;
using VRC.UI.Elements;

namespace Quantum.API.Helpers
{
    internal static class XrefUtils
    {
        public static MethodInfo GetMethod(Type pType, string pStartWith, string[] pDoesntContain, string[] pCalledMethods)
        {
            MethodInfo[] _methods = GetMethods(pType, pStartWith, pDoesntContain);

            foreach (MethodInfo _method in _methods)
            {
                IEnumerable<XrefInstance> _scan = XrefScanner.XrefScan(_method);

                if (MethodMatch(_scan, pCalledMethods))
                    return _method;
            }

            return null;
        }

        public static void ScanMethods(Type pType, string pStartWith)
        {
            MethodInfo[] _methods = pType.GetMethods().Where(method => method.Name.StartsWith(pStartWith)).ToArray();

            foreach (MethodInfo _method in _methods)
            {
                QMain.Instance.LoggerInstance.Msg(ConsoleColor.Green, _method.Name);

                IEnumerable<XrefInstance> _scan = XrefScanner.XrefScan(_method);

                MethodBase _resolvedMethod;

                foreach (XrefInstance _instance in _scan)
                {
                    _resolvedMethod = _instance.TryResolve();

                    if (_resolvedMethod != null)
                        QMain.Instance.LoggerInstance.Msg(ConsoleColor.Blue, _resolvedMethod.Name);
                }

                QMain.Instance.LoggerInstance.Msg(ConsoleColor.Green, "\n\n");
            }
        }

        private static MethodInfo[] GetMethods(Type pType, string pStartWith, string[] pDoesntContain)
        {
            List<MethodInfo> _validMethods = new List<MethodInfo>();

            MethodInfo[] _methods = pType.GetMethods().Where(method => method.Name.StartsWith(pStartWith)).ToArray();

            bool _contains = false;

            foreach (MethodInfo _method in _methods)
            {
                _contains = false;

                foreach(string _string in pDoesntContain)
                {
                    if (_method.Name.Contains(_string))
                        _contains = true;
                }

                if (!_contains)
                    _validMethods.Add(_method);
            }

            return _validMethods.ToArray();
        }

        private static bool MethodMatch(IEnumerable<XrefInstance> pScan, string[] pCalledMethods)
        {
            List<string> _calledMethodList = new List<string>();

            int _matchCount = 0;

            MethodBase _resolvedMethod;

            foreach (XrefInstance _instance in pScan)
            {
                _resolvedMethod = _instance.TryResolve();

                if (_resolvedMethod != null)
                    _calledMethodList.Add(_resolvedMethod.Name);
            }

            foreach (string _calledMethod in _calledMethodList)
            {
                foreach (string _string in pCalledMethods)
                {
                    if (_calledMethod.Contains(_string))
                        _matchCount++;
                }
            }

            if (_matchCount >= pCalledMethods.Length)
                return true;
            else
                return false;
        }
    }
}
