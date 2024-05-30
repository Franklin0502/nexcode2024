// Decompiled with JetBrains decompiler
// Type: FlameWooLogin.Program
// Assembly: FlameWooLogin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AA57480B-DD63-45C7-B0C5-EDAB3208EC55
// Assembly location: C:\Users\lucap\Desktop\2k24 cheat\NEX.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace FlameWooLogin
{
  internal static class Program
  {
    [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr LoadLibrary(string lpFileName);

    [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool FreeLibrary(IntPtr hModule);

    public static Program.DownloadFileDelegate GetDownloadFileDelegate(string functionname)
    {
      string name = "FlameWooLogin.Resources.caonima.dll";
      using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
      {
        byte[] numArray = manifestResourceStream != null ? new byte[manifestResourceStream.Length] : throw new Exception("Could not locate embedded resource");
        manifestResourceStream.Read(numArray, 0, numArray.Length);
        string tempFileName = Path.GetTempFileName();
        File.WriteAllBytes(tempFileName, numArray);
        IntPtr hModule = Program.LoadLibrary(tempFileName);
        if (hModule == IntPtr.Zero)
        {
          File.Delete(tempFileName);
          throw new Exception("Failed to load library from memory");
        }
        IntPtr procAddress = Program.GetProcAddress(hModule, functionname);
        if (procAddress == IntPtr.Zero)
        {
          Program.FreeLibrary(hModule);
          File.Delete(tempFileName);
          throw new Exception("Failed to get exported function address");
        }
        return (Program.DownloadFileDelegate) Marshal.GetDelegateForFunctionPointer(procAddress, typeof (Program.DownloadFileDelegate));
      }
    }

    public static TDelegate GetFunctionDelegate<TDelegate>(string functionName) where TDelegate : Delegate
    {
      string name = "FlameWooLogin.Resources.caonima.dll";
      using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
      {
        byte[] numArray = manifestResourceStream != null ? new byte[manifestResourceStream.Length] : throw new Exception("Could not locate embedded resource");
        manifestResourceStream.Read(numArray, 0, numArray.Length);
        string tempFileName = Path.GetTempFileName();
        File.WriteAllBytes(tempFileName, numArray);
        IntPtr hModule = Program.LoadLibrary(tempFileName);
        if (hModule == IntPtr.Zero)
        {
          File.Delete(tempFileName);
          throw new Exception("Failed to load library from memory");
        }
        IntPtr procAddress = Program.GetProcAddress(hModule, functionName);
        if (procAddress == IntPtr.Zero)
        {
          Program.FreeLibrary(hModule);
          File.Delete(tempFileName);
          throw new Exception("Failed to get exported function address for " + functionName);
        }
        return (TDelegate) Marshal.GetDelegateForFunctionPointer(procAddress, typeof (TDelegate));
      }
    }

    [STAThread]
    private static void Main()
    {
      AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Program.OnResolveAssembly);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }

    private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
    {
      string assemblyName = new AssemblyName(args.Name).Name + ".dll";
      string name = ((IEnumerable<string>) Assembly.GetExecutingAssembly().GetManifestResourceNames()).FirstOrDefault<string>((Func<string, bool>) (r => r.EndsWith(assemblyName)));
      if (name == null)
        return (Assembly) null;
      using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
      {
        byte[] numArray = new byte[manifestResourceStream.Length];
        manifestResourceStream.Read(numArray, 0, numArray.Length);
        return Assembly.Load(numArray);
      }
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ProgressCallback(
      double percentage,
      double speed,
      double downloadedMB,
      double totalMB);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool DownloadFileDelegate(
      string key,
      string url,
      Program.ProgressCallback callback);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool DriverInitDelegate();
  }
}
