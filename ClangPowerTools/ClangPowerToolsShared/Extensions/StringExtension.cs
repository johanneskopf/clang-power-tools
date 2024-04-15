using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ClangPowerTools
{
  public static class StringExtension
  {
    #region Public Methods

    public static string SubstringAfter(this string aText, string aSearchedSubstring)
    {
      if (string.IsNullOrEmpty(aSearchedSubstring))
        return aText;

      CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
      int index = compareInfo.IndexOf(aText, aSearchedSubstring, CompareOptions.Ordinal);

      if (index < 0)
        return string.Empty; //No such substring

      return aText.Substring(index + aSearchedSubstring.Length);
    }

    public static string SubstringBefore(this string aText, string aSearchedSubstring)
    {
      if (string.IsNullOrEmpty(aSearchedSubstring))
        return aSearchedSubstring;

      CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
      int index = compareInfo.IndexOf(aText, aSearchedSubstring, CompareOptions.Ordinal);

      if (index < 0)
        return string.Empty; //No such substring

      return aText.Substring(0, index);
    }

    /// <summary>
    /// String comparison using IndexOf
    /// </summary>
    /// <param name="paragrah"></param>
    /// <param name="word"></param>
    /// <param name="comp"></param>
    /// <returns></returns>
    public static bool Contains(this string paragrah, string word, StringComparison comp)
    {
      return paragrah?.IndexOf(word, comp) >= 0;
    }


    /// <summary>
    /// Get all indexes of a value
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static IEnumerable<int> AllIndexesOf(this string str, string value)
    {
      if (string.IsNullOrEmpty(value))
        throw new ArgumentException("the string to find may not be empty", "value");
      for (int index = 0; ; index += value.Length)
      {
        index = str.IndexOf(value, index);
        if (index == -1)
          break;
        yield return index;
      }
    }

    public static string Reverse(this string input)
    {
      char[] chars = input.ToCharArray();
      Array.Reverse(chars);
      return new string(chars);
    }


    public static string TrimEnd(this string input, string substring)
    {
      if (input.EndsWith(substring))
        input = input.Substring(0, input.LastIndexOf(substring));

      return input;
    }

    public static string ToReadableFormat(this string input)
    {
      if (string.IsNullOrEmpty(input))
        return input;

      var readableFormat = new StringBuilder();
      readableFormat.Append(char.ToUpper(input[0]));

      for (int i = 1; i < input.Length; i++)
      {
        if (char.IsUpper(input[i]))
        {
          readableFormat.Append(" ").Append(char.ToLower(input[i]));
        }
        else
        {
          readableFormat.Append(input[i]);
        }
      }
      return readableFormat.ToString();
    }

    #endregion

  }
}
