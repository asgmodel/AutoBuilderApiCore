﻿using AutoGenerator.Config;
using AutoMapper;
using Newtonsoft.Json;

namespace AutoGenerator.Helper.Translation   
{


    public class RoleCase
    {
        private Dictionary<string, Func<bool, object>> Roles { set; get; }

        public RoleCase()
        {
            Roles = new Dictionary<string, Func<bool, object>>();
        }

        public void Add(string key, Func<bool, object> func)
        {
            Roles.Add(key, func);
        }



        public  Dictionary<string,bool> GetRoles()
        {
            Dictionary<string, bool> roles = new Dictionary<string, bool>();
            foreach (var item in Roles)
            {
                roles.Add(item.Key, item.Value(false) != null);
            }
            return roles;
        }

        public  bool CheckRole(string key)
        {
            if (Roles.ContainsKey(key))
            {
                return Roles[key](true) != null;
            }
            return false;
        }


        public  bool IsSuccessLayer()
        {
            foreach(var item in Roles)
            {
                if (item.Value(true) == null)
                {
                    return false;
                }
            }

            return true;

        }

    }


    public class TranslationView<T>
    {
        public T Value { get; set; }
        public string LG { get; set; }
    }

    public  class TranslationData: ITranslationData
    {

        public Dictionary<string, string>? Value { get; set; }

        public string? ToFilter(string? lg)
        {
            
            if(Value == null&& Value.ContainsKey(lg))
                return  null;

            return Value[lg];



        }
    }



    public class HelperTranslation
    {



        public static readonly string KEYLG = "lg";
        public static Dictionary<string, string> ConvertTextToTranslationData(string textTranslation)
        {
            return string.IsNullOrEmpty(textTranslation)
                ? new Dictionary<string, string>()
                : JsonConvert.DeserializeObject<Dictionary<string, string>>(textTranslation);
        }


        public static TranslationData ConvertToTranslationData(string textTranslation)
        {
            return new TranslationData
            {
                Value = ConvertTextToTranslationData(textTranslation)
            };
        }

        public static string CoverTranslationDataToText(TranslationData translationData)
        {
            return JsonConvert.SerializeObject(translationData.Value);
        }


        public static string getTranslationValueByLG(string textTranslation, string lg)
        {
            return ConvertTextToTranslationData(textTranslation)[lg];
        }

        public static string ConvertTranslationDataToText(Dictionary<string, string> translationData)
        {
            return JsonConvert.SerializeObject(translationData);
        }





        public static object MapToTranslationData<S, D>(S src, D dest, object destMember, ResolutionContext context)
        {


            
            // Ensure that neither src nor dest are null
            if (src == null || dest == null)
            {
                return destMember;
            }

            // Try to get the property name in model based on the value of destMember
            var name = dest.GetType().GetProperties()
                            .FirstOrDefault(p => p.GetValue(dest) == destMember)?.Name;


           

            if (string.IsNullOrEmpty(name))
            {
                return destMember; // If property name is not found or it's null, return destMember as is
            }

            // Try to get the property value from src using the identified name
            var item = src.GetType().GetProperty(name)?.GetValue(src);
           

            
          


                if (item is ITranslationData &&destMember is ITranslationData)
            {
                return item;
            }
            // Check if item is of type ITranslationData
            if (item is ITranslationData translationData)
            {

           
                     
                    Dictionary<string, object>? items = new Dictionary<string, object>();
                context.TryGetItems(out items);

                if (items != null && items.ContainsKey(KEYLG))
                    return translationData.ToFilter((string)items[KEYLG]);

                else

                    return ConvertTranslationDataToText(translationData.Value); // Convert ITranslationData to text


            }            // Check if destMember is of type ITranslationData
            else if (destMember is ITranslationData)
            {
                // Convert the string to ITranslationData
                return ConvertToTranslationData((string)item);
            }

            var filterlg = dest.GetType().GetProperties().Where(t => GlobalAttribute.CheckFilterLGEnabled(t.PropertyType)).FirstOrDefault();
            if (filterlg != null)
            {
                var lg =filterlg.GetValue(dest);


                return getTranslationValueByLG(item.ToString(),lg.ToString());


            }
            // If item is not null, return its value
            if (item != null)
            {
                return item;
            }

            // If destMember is not null and types match, return item
            if (destMember != null && item?.GetType() == destMember?.GetType())
            {
                return item;
            }

            // In case none of the above conditions are met, return destMember as is
            return destMember;
        }


        public static object MapToStringData<S, D>(S src, D dest, object destMember, Dictionary<string, object>? items)
        {
            // Ensure that neither src nor dest are null
            if (src == null || dest == null)
            {
                return destMember;
            }

            // Try to get the property name in model based on the value of destMember
            var name = dest.GetType().GetProperties()
                            .FirstOrDefault(p => p.GetValue(dest) == destMember)?.Name;

            if (string.IsNullOrEmpty(name))
            {
                return destMember; // If property name is not found or it's null, return destMember as is
            }

            // Try to get the property value from src using the identified name
            var item = src.GetType().GetProperty(name)?.GetValue(src);

            // Check if item is of type ITranslationData
            if (item is ITranslationData translationData)
            {
                if (items != null && items.ContainsKey(KEYLG))
                     return translationData.ToFilter((string)items[KEYLG]);

                else 
            
                     return ConvertTranslationDataToText(translationData.Value); // Convert ITranslationData to text
                

            }
            // Check if destMember is of type ITranslationData
            else if (destMember is ITranslationData)
            {
                // Convert the string to ITranslationData
                return ConvertToTranslationData(item as string);
            }

            // If item is not null, return its value
            if (item != null)
            {
                return item;
            }

            // If destMember is not null and types match, return item
            if (destMember != null && item?.GetType() == destMember?.GetType())
            {
                return item;
            }

            // In case none of the above conditions are met, return destMember as is
            return destMember;
        }

    }
}
