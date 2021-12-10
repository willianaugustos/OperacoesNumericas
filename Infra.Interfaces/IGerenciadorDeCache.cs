using Dominio.Entidades;
using System;

namespace Infra.Interfaces
{
    public interface IGerenciadorDeCache
    {
        void Armazena(string chave, object item, int duracaoSegundos = 60);

        EntidadeBase RecuperaObjeto<T>(string chave) where T : EntidadeBase;
        bool? RecuperaBool(string chave);
    }
}
