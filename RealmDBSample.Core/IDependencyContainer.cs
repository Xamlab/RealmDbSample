﻿using System;

namespace RealmDBSample.Core
{
    public interface IDependencyContainer : IDisposable
    {
        T Resolve<T>();
        void Register<T, TImpl>() where TImpl : T;
        void Register<T>();
        void RegisterSingleton<T, TImpl>() where TImpl : T;
        void RegisterSingleton<T>(T implementation);
    }
}