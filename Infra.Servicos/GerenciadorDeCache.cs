using Dominio.Entidades;
using Infra.Interfaces;
using StackExchange.Redis;
using System;
using System.Diagnostics;

namespace Infra.Servicos
{
    public class GerenciadorDeCache : IGerenciadorDeCache
    {
        private ConnectionMultiplexer redisClient;
        private IDatabase redisDB;

        public GerenciadorDeCache()
        {
            try
            {
                //inicializa o client
                redisClient = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("RedisConnection"));
                redisDB = redisClient.GetDatabase();
            }
            catch (Exception e)
            {
                //não conseguiu prossegue sem o cache
                Debug.WriteLine("Ocorreu erro no acesso ao serviço de cache: " + e.ToString());
            }
        }
        public void Armazena(string chave, object item, int duracaoSegundos = 60)
        {
            if (item != null)
            {
                try
                {
                    var jsonItem = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                    redisDB.StringSet(chave, jsonItem);
                    redisDB.KeyExpire(chave, TimeSpan.FromSeconds(duracaoSegundos));
                }
                catch (Exception e)
                {
                    //não conseguiu recuperar do cache, retorna nulo
                    Debug.WriteLine("Ocorreu erro no acesso ao serviço de cache: " + e.ToString());
                }
            }
        }


        public EntidadeBase RecuperaObjeto<T>(string chave) where T : EntidadeBase
        {
            try
            {
                var strObj = redisDB.StringGet(chave);

                if (string.IsNullOrEmpty(strObj))
                    return null;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(strObj);
                return obj;
            }
            catch (Exception e)
            {
                //não conseguiu recuperar do cache, retorna nulo
                Debug.WriteLine("Ocorreu erro no acesso ao serviço de cache: " + e.ToString());
                return null;
            }
        }

        public bool? RecuperaBool(string chave)
        {
            try
            {
                var strObj = redisDB.StringGet(chave);
                if (string.IsNullOrEmpty(strObj))
                    return null;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<bool?>(strObj);
                return obj;
            }
            catch (Exception e)
            {
                //não conseguiu recuperar do cache, retorna nulo
                Debug.WriteLine("Ocorreu erro no acesso ao serviço de cache: " + e.ToString());
                return null;
            }
        }
    }
}
