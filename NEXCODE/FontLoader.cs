// Decompiled with JetBrains decompiler
// Type: FontLoader
// Assembly: FlameWooLogin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AA57480B-DD63-45C7-B0C5-EDAB3208EC55
// Assembly location: C:\Users\lucap\Desktop\2k24 cheat\NEX.exe

using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
public static class FontLoader
{
  private static readonly PrivateFontCollection privateFontCollection = new PrivateFontCollection();

  [DllImport("gdi32.dll")]
  private static extern IntPtr AddFontMemResourceEx(
    IntPtr pbFont,
    uint cbFont,
    IntPtr pdv,
    [In] ref uint pcFonts);

  public static FontFamily LoadFontFamily(byte[] fontData, out IntPtr fontBuffer)
  {
    fontBuffer = Marshal.AllocCoTaskMem(fontData.Length);
    Marshal.Copy(fontData, 0, fontBuffer, fontData.Length);
    uint pcFonts = 0;
    FontLoader.privateFontCollection.AddMemoryFont(fontBuffer, fontData.Length);
    FontLoader.AddFontMemResourceEx(fontBuffer, (uint) fontData.Length, IntPtr.Zero, ref pcFonts);
    return FontLoader.privateFontCollection.Families[0];
  }

  public static byte[] GetFontData(string resourceName)
  {
    using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
    {
      byte[] buffer = manifestResourceStream != null ? new byte[manifestResourceStream.Length] : throw new Exception("Could not find font resource");
      manifestResourceStream.Read(buffer, 0, (int) manifestResourceStream.Length);
      return buffer;
    }
  }
}
