using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Redis
{
    public class RedisProvider : IDisposable
    {
        Stopwatch sw = new Stopwatch();
        public static string RedisHostAddress = "127.0.0.1"; //=> ConfigurationManager.AppSettings["RedisHostAddress"];
        public static int RedisHostPort = 6379;  // => int.Parse(ConfigurationManager.AppSettings["RedisHostPort"]);
        public static string RedisPassword = "password";

        private static readonly object Instancelock = new object();
        private static RedisProvider _instance = null;
        private static RedisClient _client = null;
        private bool _disposed = false;

        public static RedisProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Instancelock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RedisProvider();
                            _client = new RedisClient();
                        }
                    }
                }
                return _instance;
            }
        }

        public bool SetCacheData<T>(T item, string key)
        {
            try
            {
                //using (IRedisClient client = new RedisClient(RedisHostAddress, RedisHostPort))
                using (var client = new RedisClient())
                {
                    // var item=  _client.GetConfig()();
                    var redis = client.As<T>();
                    redis.SetValue(key, item);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool SetCacheData<T>(List<T> items, string nameOfCachedVariable)
        {
            try
            {
                // using (IRedisClient client = new RedisClient(RedisHostAddress, RedisHostPort))
                //using (var client = new RedisClient())
                //{
                var redisList = _client.As<T>();
                redisList.Lists[nameOfCachedVariable].AddRange(items);
                //}

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public T GetSingleData<T>(string key)
        {
            try
            {
                sw.Start();

                using IRedisClient client = new RedisClient(RedisHostAddress, RedisHostPort, RedisPassword);
                var redis = client.As<T>();

                var t = redis.GetValue(key);
                sw.Stop();

                Console.WriteLine(sw.ElapsedMilliseconds);
                sw.Reset();
                return t;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(T);
            }
        }

        public List<T> GetAllData<T>(string nameOfCachedVariable)
        {
            try
            {
                //using (IRedisClient client = new RedisClient(RedisHostAddress, RedisHostPort, RedisPassword))
                using (var client = new RedisClient())
                {
                    var redisList = client.As<T>();
                    return redisList.Lists[nameOfCachedVariable].GetAll();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool RemoveAllData<T>(string nameOfCachedVariable)
        {
            try
            {
                //  using (IRedisClient client = new RedisClient(RedisHostAddress, RedisHostPort, RedisPassword))
                using (var client = new RedisClient())
                {
                    var redisList = client.As<T>();
                    redisList.Lists[nameOfCachedVariable].RemoveAll();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposed = true;
        }
    }
}