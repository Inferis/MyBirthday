using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MyBirthday.Helpers
{
    public static class NotifyPropertyChangedExtensions
    {
        private static Dictionary<Type, CacheItem[]> cached = new Dictionary<Type, CacheItem[]>();
        private static object cacheLock = new object();

        //public static void NotifyPropertyChanged<T>(this INotifyPropertyChanged changed, Expression<Func<T>> prop)
        //{
        //    changed.NotifyPropertyChanged(prop.GetMemberInfo().Name);
        //}

        internal static void NotifyPropertyChanged(this INotifyPropertyChanged changed, string propertyName)
        {
            CacheItem[] handlerFields;
            GetHandlerField(changed, out handlerFields);

            foreach (var handlerField in handlerFields) {
                var instance = handlerField.GetInstance(changed);
                if (instance == null) continue;
                var handler = handlerField.Field.GetValue(instance) as PropertyChangedEventHandler;
                if (handler != null)
                    handler(instance, new PropertyChangedEventArgs(propertyName));
            }
        }

        private static void GetHandlerField(INotifyPropertyChanged changed, out CacheItem[] handlerFields)
        {
            handlerFields = null;
            var type = changed.GetType();
            Func<object, object> instanceGetter;
            if (cached.ContainsKey(type)) {
                handlerFields = cached[type];
            }
            else {
                var result = new List<CacheItem>();
                while (type != null) {
                    var handlerField = type.GetField("PropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (handlerField != null) {
                        result.Add(new CacheItem(handlerField, x => x));
                    }
                    else {
                        var field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType.Name == "TrackableEntityAttribute");
                        if (field != null) {
                            var value = field.GetValue(changed);
                            if (value != null) {
                                handlerField = value.GetType().GetField("PropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic);
                                if (handlerField != null)
                                {
                                    result.Add(new CacheItem(handlerField, field, (x, ifield) => ifield.GetValue(x)));
                                }
                            }
                        }
                    }
                    type = type.BaseType;
                }

                Debug.Assert(result.Count() > 0);

                handlerFields = result.ToArray();
                lock (cacheLock) {
                    if (!cached.ContainsKey(changed.GetType()))
                        cached[changed.GetType()] = handlerFields;
                }

            }
        }

        private struct CacheItem
        {
            public CacheItem(FieldInfo field, Expression<Func<object, object>> instanceGetter)
                : this()
            {
                Field = field;
                InstanceField = null;
                GetInstance = instanceGetter.Compile();
            }

            public CacheItem(FieldInfo field, FieldInfo instanceField, Expression<Func<object, FieldInfo, object>> instanceGetter)
                : this()
            {
                Field = field;
                InstanceField = instanceField;
                GetInstance = o => instanceGetter.Compile()(o, instanceField);
            }

            public FieldInfo Field { get; private set; }
            public FieldInfo InstanceField { get; private set; }
            public Func<object, object> GetInstance { get; private set; }
        }
    }
}