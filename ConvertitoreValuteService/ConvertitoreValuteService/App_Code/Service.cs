using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service" nel codice, nel file svc e nel file di configurazione contemporaneamente.
public class Service : IService
{
	List<Valuta> lista = new List<Valuta>();
	Dictionary<string, double> dizConverti = new Dictionary<string, double>();

	public Service()
    {
		Valuta Euro = new Valuta("EUR", "Euro");
		lista.Add(Euro);
		dizConverti.Add(Euro.Nome, 1);
		Valuta Dollaro = new Valuta("USD", "Dollaro Americano");
		lista.Add(Dollaro);
		dizConverti.Add(Dollaro.Nome, 1.1655);
		Valuta Sterlina = new Valuta("GBP", "Sterlina Inglese");
		lista.Add(Sterlina);
		dizConverti.Add(Sterlina.Nome, 0.8427);
		Valuta Yen = new Valuta("JPY", "Yen Giapponese");
		lista.Add(Yen);
		dizConverti.Add(Yen.Nome, 133.12);
		Valuta Franco = new Valuta("CHF", "Franco Svizzero");
		lista.Add(Franco);
		dizConverti.Add(Franco.Nome, 1.0710);
		Valuta Canadese = new Valuta("CAD", "Dollaro Canadese");
		lista.Add(Canadese);
		dizConverti.Add(Canadese.Nome, 1.4357);
		Valuta Australiano = new Valuta("AUD", "Dollaro Australiano");
		lista.Add(Australiano);
		dizConverti.Add(Australiano.Nome, 1.5495);
		Valuta BitCoin = new Valuta("BTC", "Bitcoin");
		lista.Add(BitCoin);
		dizConverti.Add(BitCoin.Nome, 0.000017);
	}
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

	public List<Valuta> getValute()
    {
		return lista;
    }
	public double converti(double importo, string da, string a)
    {
		if(da != "Euro")
        {
			importo = importo / dizConverti[da];
			return importo * dizConverti[a];
		}
		else
			return importo * dizConverti[a];
    }
}
