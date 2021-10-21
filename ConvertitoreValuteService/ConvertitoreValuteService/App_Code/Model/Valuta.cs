using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per Valuta
/// </summary>
/// 
[DataContract]
public class Valuta
{
    [DataMember]
    public string Sigla { get; set; }
    [DataMember]
    public string Nome { get; set; }
    public Valuta(string sigla, string nome)
    {
        Sigla = sigla;
        Nome = nome;
    }

    
}