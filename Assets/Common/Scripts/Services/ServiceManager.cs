using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Services
{
    public class ServiceManager : AMonoSingleton<ServiceManager>
    {
        Dictionary<Type, object> UnlabeledServices = new Dictionary<Type, object>();
        Dictionary<TypeIDPair, object> LabeledServices = new Dictionary<TypeIDPair, object>();

        public void RegisterService<T>(T p_service, string p_id = "") where T : new()
        {
            if (p_id == string.Empty)
            {
                UnlabeledServices[typeof(T)] = p_service;
            }
            else
            {
                TypeIDPair key = new TypeIDPair(typeof(T), p_id);
                LabeledServices[key] = p_service;
            }
        }

        public T GetService<T>(string p_id = "") where T : new()
        {
            T service;
            if (p_id == string.Empty)
            {
                if (!UnlabeledServices.TryGetValue(typeof(T), out object foundService))
                {
                    service = new T();
                    UnlabeledServices[typeof(T)] = service;
                }
                else
                {
                    service = (T)foundService;
                }
            }
            else
            {
                TypeIDPair key = new TypeIDPair(typeof(T), p_id);
                if (!LabeledServices.TryGetValue(key, out object foundService))
                {
                    service = new T();
                    LabeledServices[key] = service;
                }
                else
                {
                    service = (T)foundService;
                }
            }

            return service;
        }


        private struct TypeIDPair
        {
            private Type _type;
            private string _id;

            public Type type => _type;
            public string id => _id;

            public TypeIDPair(Type p_type, string p_id)
            {
                _type = p_type;
                _id = p_id;
            }

            public override bool Equals(object obj)
            {
                if (obj is TypeIDPair other)
                {
                    return _type == other._type && _id == other._id;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(_type, _id);
            }
        }

    }

}
