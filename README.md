# Redis
Implementation Redis with .net core - C#


Redis on Windows
=============================

Redis is an open source, high performance, key-value store. Values may contain strings, hashes, lists, sets and sorted sets. Redis has been developed primarily for UNIX-like operating systems.
Our goal is to provide a version of Redis that runs on Windows with a performance essentially equal to the performance of Redis on an equivalent UNIX machine.

How to Run and use Redis on Windows

1-Download Redis-x64-3.0.504.msi and run it.

2-Open cmd and Type:
  Redis CLI

3-Download redis-desktop-manager-0.9.3.817.exe 

nuget:
			ServiceStack.Redis.Core
===================


SetObjectCachData on Redis:

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
						
	SetObjectBactchCachData					
						
				public bool SetCacheData<T>(List<T> items, string nameOfCachedVariable)
        {
            try
            {
                // using (IRedisClient client = new RedisClient(RedisHostAddress, RedisHostPort))
                using (var client = new RedisClient())
                {
                    var redisList = client.As<T>();
                    redisList.Lists[nameOfCachedVariable].AddRange(items);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
						
GetSingleData:

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
						
GetAllData:

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
						
						
RemoveAllData:

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
					
Dispose:
	

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
					
