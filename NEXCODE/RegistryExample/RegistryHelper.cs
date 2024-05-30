// Decompiled with JetBrains decompiler
// Type: RegistryExample.RegistryHelper
// Assembly: FlameWooLogin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AA57480B-DD63-45C7-B0C5-EDAB3208EC55
// Assembly location: C:\Users\lucap\Desktop\2k24 cheat\NEX.exe

using Microsoft.Win32;
using System;

#nullable disable
namespace RegistryExample
{
  public static class RegistryHelper
  {
    public static void WriteToRegistry(
      RegistryKey rootKey,
      string keyPath,
      string valueName,
      string valueData)
    {
      using (RegistryKey subKey = rootKey.CreateSubKey(keyPath))
      {
        subKey.SetValue(valueName, (object) valueData);
        Console.WriteLine("注册表写入成功！");
      }
    }

    public static string ReadFromRegistry(RegistryKey rootKey, string keyPath, string valueName)
    {
      using (RegistryKey registryKey = rootKey.OpenSubKey(keyPath))
      {
        if (registryKey != null)
        {
          object obj = registryKey.GetValue(valueName);
          if (obj != null)
            return obj.ToString();
        }
      }
      return (string) null;
    }
  }
}
