using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using BenchMarkApp.EnumVsStringArray;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchMarkApp.EnumVsStringArray
{
    /// <summary>
    /// This is a bench mark that compares 2 methods of getting a string from an Enum.  The baseline method is more hard-coded/hackish and requires more upfront effort but 1000x faster.
    /// The second method, uses an extension method and the Description attribute from the enum to get the string value.  This is much cleaner, but much significantly slower.
    /// </summary>
    public class EnumVsStringArray
    {
        private EnumColors max = EnumColors.Black + 1;


        public EnumVsStringArray() { }
        
        #region "BenchMark Baseline"


        [Benchmark(Baseline = true)]
        public void AccessIntoStringArray()
        {
            for (EnumColors i = 0; i < max; i++)
            {
                TestPassingEnumValue(i);
            }
        }



        public void TestPassingEnumValue(EnumColors color)
        {
            string value = EnumAsStrings.Values[(int)color];
        }
        #endregion


        #region "Benchmark x"

        [Benchmark]
        public void AccessViaEnumDescription()
        {
            for (EnumColors i = 0; i < max; i++)
            {
                string desc = i.GetDescription();
                TestPassingString(desc);
            }

        }



        public void TestPassingString(string value)
        {
            return;
        }

        #endregion

    }


    public static class EnumExtensionMethods
    {
        public static string GetDescription(this Enum GenericEnum) //Hint: Change the method signature and input paramter to use the type parameter T
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }

    }
}

