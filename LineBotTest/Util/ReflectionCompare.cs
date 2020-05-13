using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace LineBotTest.Util
{
    internal static class ReflectionCompare
    {
        public static void Compare(object got, object expect)
        {
            string compareResult = Equals(got, expect);
            if (compareResult != null)
            {
                Assert.Fail(compareResult);
            }
        }

        static new string Equals(object got, object expect)
        {
            if (got == null && expect == null)
                return null;
            else if (got == null || expect == null)
            {
                return $"expect: {expect}\n" +
                         $"got: {got}";
            }

            Type expectType = expect.GetType();
            if (got.GetType() != expectType)
            {
                return "Wrong Type";
            }

            if (expectType == typeof(int) ||
                expectType == typeof(string) ||
                expectType == typeof(float) ||
                expectType == typeof(double) ||
                expectType == typeof(decimal) ||
                expectType == typeof(long) ||
                expectType.IsEnum)
            {
                if (!expect.Equals(got))
                {
                    return $"expect: {expect}\n" +
                        $"got: {got}";
                }
                return null;
            }
            
            if (expectType.IsArray)
            {
                Array gotArr = (Array)got;
                Array expectArr = (Array)expect;
                if (gotArr.Length != expectArr.Length)
                {
                    return $"wrong len expect: {expectArr.Length}, got: {gotArr.Length}";
                }

                for (int i = 0; i < expectArr.Length; i++)
                {
                    object expectValue = expectArr.GetValue(i);
                    object gotValue = gotArr.GetValue(i);

                    string compareResult = Equals(gotValue, expectValue);
                    if (compareResult != null)
                    {
                        return $"index: {i}:\n" +
                            $"{compareResult}";
                    }
                }
            }
            else if (expectType.IsClass)
            {
                //foreach每一個欄位屬性及值,並進行判斷儲存

                foreach (FieldInfo element in expectType.GetFields())
                {
                    try
                    {
                        object expectValue = element.GetValue(expect);
                        if (element.IsStatic && expectValue?.GetType() == expectType)
                        {
                            continue;
                        }
                        object gotValue = element.GetValue(got);
                        
                        string compareResult = Equals(gotValue, expectValue);
                        if (compareResult != null)
                        {
                            return $"{element.Name}:\n" +
                                $"{compareResult}";
                        }
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
                foreach (PropertyInfo element in expectType.GetProperties())
                {
                    if (!element.CanRead)
                    {
                        return "Can Not Read";
                    }

                    try
                    {
                        object expectValue = element.GetValue(expect);
                        object gotValue = element.GetValue(got);
                        string compareResult = Equals(gotValue, expectValue);
                        if (compareResult != null)
                        {
                            return $"{element.Name}:\n" +
                                $"{compareResult}";
                        }
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }
            else
            {
                return "Unknow Type";
            }
            return null;
        }
    }
}
