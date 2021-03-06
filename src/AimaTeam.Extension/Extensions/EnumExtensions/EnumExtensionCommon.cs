﻿/*
 *
 *   Copyright © 2015-Presents AimaTeam
 * 
 *   author：he hai
 *   time：2015/05/08
  
 *   QQ Group：139849106
 *   Web Site：https://www.aimateam.org
 *   
 *   Licensed to the AimaTeam Open Source under one or more agreements.
 *   The AimaTeam Open Source licenses this file to you under the MIT license. 
 *   
 *   The MIT License
 *   
 *   Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
 *   documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
 *   the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
 *   to permit persons to whom the Software is furnished to do so, subject to the following conditions:　　
 *   The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

 *   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
 *   THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
 *   THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
 *   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *
 */

using System;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

namespace AimaTeam.Extension
{
    using Utilities;

    /// <summary>
    /// 枚举常用操作而定义的扩展方法静态类
    /// </summary>
    public static partial class EnumExtensionCommon
    {
        /// <summary>
        /// 获取枚举的键
        /// </summary>
        /// <param name="enumSrc">枚举对象</param>
        /// <returns></returns>
        public static string GetKey(this Enum enumSrc)
        {
            return Enum.GetName(enumSrc.GetType(), enumSrc);
        }

        /// <summary>
        /// 获取枚举的值
        /// </summary>
        /// <param name="enumSrc">枚举对象</param>
        /// <returns></returns>
        public static TValue GetValue<TValue>(this Enum enumSrc)
        {
            int valueIndex = 0;
            string enumSrcKey = enumSrc.GetKey();
            foreach (var item in Enum.GetNames(enumSrc.GetType()))
            {
                if (enumSrcKey.EqualIgnoreCase(item))
                {
                    return (TValue)Enum.GetValues(enumSrc.GetType()).GetValue(valueIndex);
                }
                valueIndex++;
            }
            throw ExceptionUtility.Create<InvalidCastException>("The {0} invalid".FormatExt(enumSrc));
        }

        /// <summary>
        /// 获取枚举的描述,没有System.ComponentModel.DescriptionAttribute标记返回string.Empty
        /// </summary>
        /// <param name="enumSrc">枚举对象</param>
        /// <returns></returns>
        public static string GetDescriptorText(this Enum enumSrc)
        {

#if COREFX
            FieldInfo field =System.Reflection.TypeExtensions.GetField(enumSrc.GetType(), enumSrc.ToString());
            DescriptionAttribute[] desciptors = field.GetDescriptionAttributes().ToArray();
#else
            FieldInfo field = enumSrc.GetType().GetField(enumSrc.ToString());
            DescriptionAttribute[] desciptors = field.GetDescriptionAttributes().ToArray();
#endif
            if (desciptors.Length > 0)
                return desciptors[0].Description;
            return string.Empty;
        }

        /// <summary>
        /// 获取int枚举类型的值
        /// </summary>
        /// <param name="enumSrc">枚举对象</param>
        /// <returns></returns>
        public static int GetValueAsInt(this Enum enumSrc)
        {
            return enumSrc.GetValue<int>();
        }

        /// <summary>
        /// 获取byte枚举类型的值
        /// </summary>
        /// <param name="enumSrc">枚举对象</param>
        /// <returns></returns>
        public static byte GetValueAsByte(this Enum enumSrc)
        {
            return enumSrc.GetValue<byte>();
        }

        /// <summary>
        /// 获取Long/Int64枚举类型的值
        /// </summary>
        /// <param name="enumSrc">枚举对象</param>
        /// <returns></returns>
        public static long GetValueAsLong(this Enum enumSrc)
        {
            return enumSrc.GetValue<long>();
        }

        /// <summary>
        /// 判断指定的枚举 enumSrc 是否等于anyEnums中的任何一个,是：返回true,否则返回false
        /// </summary>
        /// <param name="enumSrc">枚举对象</param>
        /// <param name="anyEnums">需要比较进行判断的枚举数组</param>
        /// <returns></returns>
        public static bool IsAnyOne(this Enum enumSrc,params Enum[] anyEnums)
        {
            for (int i = 0; i < anyEnums.Length; i++)
                if (anyEnums[i] == enumSrc) return true;
            return false;
        }

        /// <summary>
        /// 获取指定参数枚举值,包含了键/值以及Attribute附加属性的等等的 <see cref="EnumInfo{TValue}"/> 对象
        /// </summary>
        /// <typeparam name="TValue">指定枚举没的枚举值的。net数据类型</typeparam>
        /// <param name="enumSrc">指定的枚举键值</param>
        /// <returns></returns>
        public static EnumInfo<TValue> GetEnumInfo<TValue>(this Enum enumSrc)
        {
            return enumSrc.GetEnumInfoCollection<TValue>().FirstOrDefault(p => p.Name == enumSrc.GetKey());
        }

        /// <summary>
        /// 获取指定参数枚举值,包含了键/值以及Attribute附加属性的等等的 <see cref="EnumInfoCollection{TValue}"/> 集合
        /// </summary>
        /// <typeparam name="TValue">指定枚举没的枚举值的。net数据类型</typeparam>
        /// <param name="enumSrc">指定的枚举键值</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public static EnumInfoCollection<TValue> GetEnumInfoCollection<TValue>(this Enum enumSrc)
        {
            return new EnumInfoCollection<TValue>(enumSrc.GetType());
        }
    }
}