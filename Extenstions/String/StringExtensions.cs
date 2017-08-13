using System;
using System.Collections.Generic;
using System.Text;

namespace USTVA.Tools.Extenstions.String
{
    public static class StringExtensions
    {

        /// <summary>
        /// Removes a string from specified collections of omissions
        /// if none are found in the sequence, the original string is returned
        /// </summary>
        /// <param name="field">string to remove from</param>
        /// <param name="omissions">an array of omissions to remove from string</param>
        /// <returns> A new string without the found omission[i], or the original if none found</returns>
        public static string RemoveAny(this string field, string[] omissions)
        {
            for (int i = 0; i < omissions.Length; i++)
            {
                if (field.Contains(omissions[i]))
                { 
                    field = field.Remove(0, omissions[i].Length + 1);
                }
            }
            return field;
        }

        /// <summary>
        /// Replaces a string with a newValue 
        /// if the current string contains any strings 
        /// specified in oldValues
        /// </summary>
        /// <param name="text"></param>
        /// <param name="newValue"></param>
        /// <param name="oldValues">values to omit from source</param>
        /// <returns></returns>
        public static string ReplaceAny(this string text, string newValue, params string[] oldValues)
        {
            string result = text;

            for (int i = 0; i < oldValues.Length; i++)
            {
                if (result.Contains(oldValues[i])) result = text.Replace(oldValues[i], newValue);
            }

            return result;
        }

        /// <summary>
        /// Splits supporting escape characters
        /// </summary>
        /// <param name="text"></param>
        /// <param name="separator"></param>
        /// <param name="escapeCharacter"></param>
        /// <param name="removeEmptyEntries"></param>
        /// <returns></returns>
        public static IEnumerable<string> Split(this string text, char separator, char escapeCharacter, bool removeEmptyEntries)
        {
            string buffer = string.Empty;
            bool escape = false;

            foreach (var c in text)
            {
                if (!escape && c == separator)
                {
                    if (!removeEmptyEntries || buffer.Length > 0)
                    {
                        yield return buffer;
                    }

                    buffer = string.Empty;
                }
                else
                {
                    if (c == escapeCharacter)
                    {
                        escape = !escape;

                        if (!escape)
                        {
                            buffer = string.Concat(buffer, c);
                        }
                    }
                    else
                    {
                        if (!escape)
                        {
                            buffer = string.Concat(buffer, c);
                        }

                        escape = false;
                    }
                }
            }

            if (buffer.Length != 0)
            {
                yield return buffer;
            }
        }
    }
}
